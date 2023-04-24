using NerdStore.Catalog.Application.ViewModels;

namespace NerdStore.Catalog.Application.Interfaces
{
    public interface IProductAppService : IDisposable
    {
        Task<ProductViewModel?> GetProductByIdAsync(Guid productId);
        Task<IEnumerable<ProductViewModel>> GetAllProductsAsync();
        Task<IEnumerable<ProductViewModel>> GetAllProductsByCategoryCodeAsync(int categoryCode);
        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();
        Task AddProductAsync(ProductViewModel productViewModel);
        Task UpdateProductAsync(ProductViewModel productViewModel);
        Task<ProductViewModel> AddToStockAsync(Guid productId, int quantity);
        Task<ProductViewModel> RemoveFromStockAsync(Guid productId, int quantity);
    }
}
