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
                order.Voucher?.Code);

            foreach (var item in order.Items)
            {
                cart.Items.Add(new(
                    item.ProductId,
                    item.ProductName,
                    item.Quantity,
                    item.Price,
                    item.GetTotal()));
            }

            return cart;
        }

        public async Task<IEnumerable<OrderViewModel>> GetPaidAndCanceledOrdersByClientIdAsync(Guid clientId)
        {
            var orders = await _orderRepository.GetPaidAndCanceledOrdersByClientIdAsync(clientId);

            var viewModel = new List<OrderViewModel>();

            foreach (var order in orders)
            {
                viewModel.Add(new(
                    order.Code,
                    order.Total,
                    (int)order.Status,
                    order.CreatedAt));
            }

            return viewModel.OrderByDescending(o => o.Code);
        }
    }
}
