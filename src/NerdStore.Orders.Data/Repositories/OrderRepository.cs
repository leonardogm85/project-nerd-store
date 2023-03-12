using Microsoft.EntityFrameworkCore;
using NerdStore.Core.Data;
using NerdStore.Orders.Data.Context;
using NerdStore.Orders.Domain.Entities;
using NerdStore.Orders.Domain.Interfaces.Repositories;

namespace NerdStore.Orders.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;

        public OrderRepository(OrderContext context) => _context = context;

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Order?> GetOrderByIdAsync(Guid orderId)
        {
            return await _context
                .Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<Order?> GetDraftOrderByClientIdAsync(Guid clientId)
        {
            return await _context
                .Orders
                .AsNoTracking()
                .Include(o => o.Items)
                .Include(o => o.Voucher)
                .FirstOrDefaultAsync(o => o.ClientId == clientId && o.Status == Status.Draft);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersByClientIdAsync(Guid clientId)
        {
            return await _context
                .Orders
                .AsNoTracking()
                .Where(o => o.ClientId == clientId)
                .ToListAsync();
        }

        public void AddOrder(Order order) => _context.Orders.Add(order);

        public void UpdateOrder(Order order) => _context.Orders.Update(order);

        public async Task<Item?> GetItemByIdAsync(Guid itemId)
        {
            return await _context
                .Items
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == itemId);
        }

        public async Task<Item?> GetItemByOrderIdAndProductIdAsync(Guid orderId, Guid productId)
        {
            return await _context
                .Items
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.OrderId == orderId && i.ProductId == productId);
        }

        public void AddItem(Item item) => _context.Items.Add(item);

        public void UpdateItem(Item item) => _context.Items.Update(item);

        public void RemoveItem(Item item) => _context.Items.Remove(item);

        public async Task<Voucher?> GetVoucherByCodeAsync(string code)
        {
            return await _context
                .Vouchers
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.Code == code);
        }

        public void Dispose() => _context.Dispose();
    }
}
