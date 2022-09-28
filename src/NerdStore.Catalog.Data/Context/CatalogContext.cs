using Microsoft.EntityFrameworkCore;
using NerdStore.Catalog.Data.Mappings;
using NerdStore.Catalog.Domain.Entities;
using NerdStore.Core.Data;

namespace NerdStore.Catalog.Data.Context
{
    public class CatalogContext : DbContext, IUnitOfWork
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; private set; }
        public DbSet<Category> Categories { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new CategoryMapping());
        }

        public async Task<bool> CommitAsync()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}
