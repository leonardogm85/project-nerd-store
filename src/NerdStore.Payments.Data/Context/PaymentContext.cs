using Microsoft.EntityFrameworkCore;
using NerdStore.Core.Data;
using NerdStore.Core.Mediator;
using NerdStore.Payments.Data.Extensions;
using NerdStore.Payments.Data.Mappings;
using NerdStore.Payments.Domain.Entities;

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

        public void Rollback()
        {
            ChangeTracker.Clear();
        }

        public async Task<bool> CommitAsync()
        {
            var entitiesSaved = await SaveChangesAsync() > 0;

            if (entitiesSaved)
            {
                await _mediatorHandler.PublishEventsAsync(this);
            }

            return entitiesSaved;
        }
    }
}
