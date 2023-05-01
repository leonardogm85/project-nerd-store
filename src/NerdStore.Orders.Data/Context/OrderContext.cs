using Microsoft.EntityFrameworkCore;
using NerdStore.Core.Mediator;
using NerdStore.Core.Data;
using NerdStore.Orders.Data.Extensions;
using NerdStore.Orders.Data.Mappings;
using NerdStore.Orders.Domain.Entities;

namespace NerdStore.Orders.Data.Context
{
    public class OrderContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public OrderContext(DbContextOptions<OrderContext> options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<Voucher> Vouchers => Set<Voucher>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderMapping());
            modelBuilder.ApplyConfiguration(new ItemMapping());
            modelBuilder.ApplyConfiguration(new VoucherMapping());

            modelBuilder
                .HasSequence<int>("MySequence")
                .StartsAt(1000)
                .IncrementsBy(1);

            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> CommitAsync()
        {
            if (await SaveChangesAsync() > 0)
            {
                await _mediatorHandler.PublishEventsAsync(this);

                return true;
            }

            return false;
        }
    }
}
