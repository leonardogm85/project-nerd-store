using Microsoft.EntityFrameworkCore;
using NerdStore.Catalog.Data.Extensions;
using NerdStore.Catalog.Data.Mappings;
using NerdStore.Catalog.Domain.Entities;
using NerdStore.Core.Data;
using NerdStore.Core.Mediator;

namespace NerdStore.Catalog.Data.Context
{
    public sealed class CatalogContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public CatalogContext(DbContextOptions<CatalogContext> options, IMediatorHandler mediatorHandler)
            : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new CategoryMapping());
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
