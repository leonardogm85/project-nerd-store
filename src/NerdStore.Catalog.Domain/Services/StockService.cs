using NerdStore.Catalog.Domain.Events;
using NerdStore.Catalog.Domain.Interfaces.Repositories;
using NerdStore.Catalog.Domain.Interfaces.Services;
using NerdStore.Core.Mediator;

namespace NerdStore.Catalog.Domain.Services
{
    public class StockService : IStockService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public StockService(IProductRepository productRepository, IMediatorHandler mediatorHandler)
        {
            _productRepository = productRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> AddToStockAsync(Guid productId, int quantity)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);

            if (product == null)
            {
                return false;
            }

            product.AddToStock(quantity);

            _productRepository.UpdateProduct(product);

            return await _productRepository.UnitOfWork.CommitAsync();
        }

        public async Task<bool> RemoveFromStockAsync(Guid productId, int quantity)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);

            if (product == null)
            {
                return false;
            }

            if (!product.HasStock(quantity))
            {
                return false;
            }

            product.RemoveFromStock(quantity);

            if (product.LowStock())
            {
                var @event = new ProductWithLowStockEvent(
                    productId,
                    quantity);

                await _mediatorHandler.PublishEventAsync(@event);
            }

            _productRepository.UpdateProduct(product);

            return await _productRepository.UnitOfWork.CommitAsync();
        }

        public void Dispose() => _productRepository.Dispose();
    }
}
