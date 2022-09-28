using NerdStore.Catalog.Domain.Entities;
using NerdStore.Core.Data;

namespace NerdStore.Catalog.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(Guid productId);
        Task<IEnumerable<Product>> GetAllProductsByCategoryCodeAsync(int categoryCode);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
    }
}
