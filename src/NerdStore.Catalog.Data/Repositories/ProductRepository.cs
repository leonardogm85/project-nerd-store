using Microsoft.EntityFrameworkCore;
using NerdStore.Catalog.Data.Context;
using NerdStore.Catalog.Domain.Entities;
using NerdStore.Catalog.Domain.Interfaces.Repositories;
using NerdStore.Core.Data;

namespace NerdStore.Catalog.Data.Repositories
{
    public sealed class ProductRepository : IProductRepository
    {
        private readonly CatalogContext _context;

        public ProductRepository(CatalogContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public async Task<Product?> GetProductByIdAsync(Guid productId)
        {
            return await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(product => product.Id == productId);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsByCategoryCodeAsync(int categoryCode)
        {
            return await _context.Products
                .AsNoTracking()
                .Include(product => product.Category)
                .Where(product => product.Category!.Code == categoryCode)
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .AsNoTracking()
                .ToListAsync();
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
