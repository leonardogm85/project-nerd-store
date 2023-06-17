using NerdStore.Orders.Application.Queries.ViewModels;
using NerdStore.Orders.Domain.Interfaces.Repositories;

namespace NerdStore.Orders.Application.Queries
{
    public class OrderQuery : IOrderQuery
    {
        private readonly IOrderRepository _orderRepository;

        public OrderQuery(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<CartViewModel?> GetDraftOrderByClientIdAsync(Guid clientId)
        {
            var order = await _orderRepository.GetDraftOrderByClientIdAsync(clientId);

            if (order is null)
            {
                return null;
            }

            var cart = new CartViewModel(
                order.Id,
                order.ClientId,
                order.Total + order.Discount,
                order.Discount,
                order.Total,
                order.Voucher?.Code,
                order.Items.Select(item => new CartItemViewModel(
                    item.ProductId,
                    item.ProductName,
                    item.Quantity,
                    item.Price,
                    item.GetTotal())));

            return cart;
        }

        public async Task<IEnumerable<OrderViewModel>> GetPaidAndCanceledOrdersByClientIdAsync(Guid clientId)
        {
            var orders = await _orderRepository.GetPaidAndCanceledOrdersByClientIdAsync(clientId);

            return orders.Select(order => new OrderViewModel(
                    order.Code,
                    order.Total,
                    (int)order.Status,
                    order.CreatedAt))
                .OrderByDescending(order => order.Code);
        }
    }
}
