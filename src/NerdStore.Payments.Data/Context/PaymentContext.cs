using Microsoft.EntityFrameworkCore;
using NerdStore.Core.Data;
using NerdStore.Core.Mediator;
using NerdStore.Payments.Domain.Entities;
using NerdStore.Payments.Data.Extensions;
using NerdStore.Payments.Data.Mappings;

namespace NerdStore.Payments.Data.Context
{
    public class PaymentContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public PaymentContext(DbContextOptions<PaymentContext> options, IMediatorHandler mediatorHandler)
            : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<Transaction> Transactions => Set<Transaction>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaymentMapping());
            modelBuilder.ApplyConfiguration(new TransactionMapping());

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
