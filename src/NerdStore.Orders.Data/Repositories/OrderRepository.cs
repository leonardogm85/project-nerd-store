using Microsoft.EntityFrameworkCore;
using NerdStore.Core.Data;
using NerdStore.Orders.Data.Context;
using NerdStore.Orders.Domain.Entities;
using NerdStore.Orders.Domain.Interfaces.Repositories;

namespace NerdStore.Orders.Data.Repositories
{
    public sealed class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public OrderRepository(OrderContext context)
        {
            _context = context;
        }

        public async Task<Order?> GetOrderByIdAsync(Guid orderId)
        {
            return await _context
                .Orders
                .AsNoTracking()
                .Include(o => o.Voucher)
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<Order?> GetDraftOrderByClientIdAsync(Guid clientId)
        {
            return await _context
                .Orders
                .AsNoTracking()
                .Include(o => o.Voucher)
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.ClientId == clientId && o.Status == Status.Draft);
        }

        public async Task<IEnumerable<Order>> GetOrdersByClientIdAsync(Guid clientId)
        {
            return await _context
                .Orders
                .AsNoTracking()
                .Where(o => o.ClientId == clientId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetPaidAndCanceledOrdersByClientIdAsync(Guid clientId)
        {
            return await _context
                .Orders
                .AsNoTracking()
                .Where(o => o.ClientId == clientId && (o.Status == Status.Paid || o.Status == Status.Canceled))
                .ToListAsync();
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
        }

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

        public async Task<IEnumerable<Item>> GetItemsByOrderIdAsync(Guid orderId)
        {
            return await _context
                .Items
                .AsNoTracking()
                .Where(i => i.OrderId == orderId)
                .ToListAsync();
        }

        public void AddItem(Item item)
        {
            _context.Items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            _context.Items.Update(item);
        }

        public void RemoveItem(Item item)
        {
            _context.Items.Remove(item);
        }

        public async Task<Voucher?> GetVoucherByIdAsync(Guid voucherId)
        {
            return await _context
                .Vouchers
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.Id == voucherId);
        }

        public async Task<Voucher?> GetVoucherByCodeAsync(string voucherCode)
        {
            return await _context
                .Vouchers
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.Code == voucherCode);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
