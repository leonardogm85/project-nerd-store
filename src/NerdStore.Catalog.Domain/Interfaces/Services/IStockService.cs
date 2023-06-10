using NerdStore.Catalog.Domain.DataTransferObjects;

namespace NerdStore.Catalog.Domain.Interfaces.Services
{
    public interface IStockService : IDisposable
    {
        Task<bool> AddProductToStockAsync(Guid productId, int quantity);
        Task<bool> RemoveProductFromStockAsync(Guid productId, int quantity);
        Task<bool> AddProductsToStockAsync(IEnumerable<AddProductToStockDataTransferObject> products);
        Task<bool> RemoveProductsFromStockAsync(IEnumerable<RemoveProductFromStockDataTransferObject> products);
    }
}
