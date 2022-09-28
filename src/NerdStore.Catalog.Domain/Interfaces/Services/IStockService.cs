namespace NerdStore.Catalog.Domain.Interfaces.Services
{
    public interface IStockService : IDisposable
    {
        Task<bool> AddToStockAsync(Guid productId, int quantity);
        Task<bool> RemoveFromStockAsync(Guid productId, int quantity);
    }
}
