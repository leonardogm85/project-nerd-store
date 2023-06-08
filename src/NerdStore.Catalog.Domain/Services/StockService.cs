using NerdStore.Catalog.Domain.DataTransferObjects;
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

        public async Task<bool> AddProductToStockAsync(AddProductToStockDataTransferObject addProductToStock)
        {
            if (await AddToStockAsync(addProductToStock.ProductId, addProductToStock.Quantity))
            {
                return await _productRepository.UnitOfWork.CommitAsync();
            }

            return false;
        }

        public async Task<bool> RemoveProductFromStockAsync(RemoveProductFromStockDataTransferObject removeProductFromStock)
        {
            if (await RemoveFromStockAsync(removeProductFromStock.ProductId, removeProductFromStock.Quantity))
            {
                return await _productRepository.UnitOfWork.CommitAsync();
            }

            return false;
        }

        public async Task<bool> AddProductsToStockAsync(IEnumerable<AddProductToStockDataTransferObject> addProductsToStock)
        {
            foreach (var addProductToStock in addProductsToStock)
            {
                if (await AddToStockAsync(addProductToStock.ProductId, addProductToStock.Quantity))
                {
                    continue;
                }

                return false;
            }

            return await _productRepository.UnitOfWork.CommitAsync();
        }

        public async Task<bool> RemoveProductsFromStockAsync(IEnumerable<RemoveProductFromStockDataTransferObject> removeProductsFromStock)
        {
            foreach (var removeProductFromStock in removeProductsFromStock)
            {
                if (await RemoveFromStockAsync(removeProductFromStock.ProductId, removeProductFromStock.Quantity))
                {
                    continue;
                }

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
