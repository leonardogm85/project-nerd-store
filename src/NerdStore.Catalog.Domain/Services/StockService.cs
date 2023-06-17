using NerdStore.Catalog.Domain.DataTransferObjects;
using NerdStore.Catalog.Domain.Entities;
using NerdStore.Catalog.Domain.Events;
using NerdStore.Catalog.Domain.Interfaces.Repositories;
using NerdStore.Catalog.Domain.Interfaces.Services;
using NerdStore.Core.Mediator;

namespace NerdStore.Catalog.Domain.Services
{
    public sealed class StockService : IStockService
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IProductRepository _productRepository;

        public StockService(IMediatorHandler mediatorHandler, IProductRepository productRepository)
        {
            _mediatorHandler = mediatorHandler;
            _productRepository = productRepository;
        }

        public async Task<bool> AddProductToStockAsync(Guid productId, int quantity)
        {
            if (await AddToStockAsync(productId, quantity))
            {
                return await _productRepository.UnitOfWork.CommitAsync();
            }

            _productRepository.UnitOfWork.Rollback();

            return false;
        }

        public async Task<bool> RemoveProductFromStockAsync(Guid productId, int quantity)
        {
            if (await RemoveFromStockAsync(productId, quantity))
            {
                return await _productRepository.UnitOfWork.CommitAsync();
            }

            _productRepository.UnitOfWork.Rollback();

            return false;
        }

        public async Task<bool> AddProductsToStockAsync(IEnumerable<AddProductToStockDataTransferObject> products)
        {
            foreach (var product in products)
            {
                if (await AddToStockAsync(product.ProductId, product.Quantity))
                {
                    continue;
                }

                _productRepository.UnitOfWork.Rollback();

                return false;
            }

            return await _productRepository.UnitOfWork.CommitAsync();
        }

        public async Task<bool> RemoveProductsFromStockAsync(IEnumerable<RemoveProductFromStockDataTransferObject> products)
        {
            foreach (var product in products)
            {
                if (await RemoveFromStockAsync(product.ProductId, product.Quantity))
                {
                    continue;
                }

                _productRepository.UnitOfWork.Rollback();

                return false;
            }

            return await _productRepository.UnitOfWork.CommitAsync();
        }

        public void Dispose()
        {
            _productRepository.Dispose();
        }

        private async Task<bool> AddToStockAsync(Guid productId, int quantity)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);

            if (product is null)
            {
                return false;
            }

            product.AddToStock(quantity);

            _productRepository.UpdateProduct(product);

            return true;
        }

        private async Task<bool> RemoveFromStockAsync(Guid productId, int quantity)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);

            if (product is null)
            {
                return false;
            }

            var hasStock = product.HasStock(quantity);

            if (!hasStock)
            {
                await _mediatorHandler.PublishDomainNotificationAsync(new(
                    nameof(Product),
                    $"Insufficient stock of product {product.Name} ({product.QuantityInStock} in stock)."));

                return false;
            }

            product.RemoveFromStock(quantity);

            if (product.LowStock())
            {
                var @event = new ProductWithLowStockEvent(
                    productId,
                    quantity);

                await _mediatorHandler.PublishDomainEventAsync(@event);
            }

            _productRepository.UpdateProduct(product);

            return true;
        }
    }
}
