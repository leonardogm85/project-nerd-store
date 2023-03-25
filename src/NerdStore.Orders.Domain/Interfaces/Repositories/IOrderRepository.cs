using NerdStore.Core.Data;
using NerdStore.Orders.Domain.Entities;

namespace NerdStore.Orders.Domain.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order?> GetOrderByIdAsync(Guid orderId);
        Task<Order?> GetDraftOrderByClientIdAsync(Guid clientId);
        Task<IEnumerable<Order>> GetAllOrdersByClientIdAsync(Guid clientId);
        Task<IEnumerable<Order>> GetAllPaidAndCanceledOrdersByClientIdAsync(Guid clientId);
        void AddOrder(Order order);
        void UpdateOrder(Order order);

        Task<Item?> GetItemByIdAsync(Guid itemId);
        Task<Item?> GetItemByOrderIdAndProductIdAsync(Guid orderId, Guid productId);
        void AddItem(Item item);
        void UpdateItem(Item item);
        void RemoveItem(Item item);

        Task<Voucher?> GetVoucherByCodeAsync(string code);
    }
}
