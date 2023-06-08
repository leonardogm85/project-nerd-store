using NerdStore.Catalog.Domain.DataTransferObjects;

namespace NerdStore.Catalog.Domain.Interfaces.Services
{
    public interface IStockService : IDisposable
    {
        Task<bool> AddProductToStockAsync(AddProductToStockDataTransferObject addProductToStock);
        Task<bool> RemoveProductFromStockAsync(RemoveProductFromStockDataTransferObject removeProductFromStock);
        Task<bool> AddProductsToStockAsync(IEnumerable<AddProductToStockDataTransferObject> addProductsToStock);
        Task<bool> RemoveProductsFromStockAsync(IEnumerable<RemoveProductFromStockDataTransferObject> removeProductsFromStock);
    }
}
