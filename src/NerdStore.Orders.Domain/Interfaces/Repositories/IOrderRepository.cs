using NerdStore.Core.Data;
using NerdStore.Orders.Domain.Entities;

namespace NerdStore.Orders.Domain.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order?> GetOrderByIdAsync(Guid orderId);
        Task<Order?> GetDraftOrderByClientIdAsync(Guid clientId);
        Task<IEnumerable<Order>> GetOrdersByClientIdAsync(Guid clientId);
        Task<IEnumerable<Order>> GetPaidAndCanceledOrdersByClientIdAsync(Guid clientId);
        void AddOrder(Order order);
        void UpdateOrder(Order order);

        Task<Item?> GetItemByIdAsync(Guid itemId);
        Task<Item?> GetItemByOrderIdAndProductIdAsync(Guid orderId, Guid productId);
        Task<IEnumerable<Item>> GetItemsByOrderIdAsync(Guid orderId);
        void AddItem(Item item);
        void UpdateItem(Item item);
        void RemoveItem(Item item);

        Task<Voucher?> GetVoucherByIdAsync(Guid voucherId);
        Task<Voucher?> GetVoucherByCodeAsync(string voucherCode);
    }
}
