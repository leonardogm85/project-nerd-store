using Moq;
using NerdStore.Catalog.Domain.Interfaces.Repositories;
using NerdStore.Catalog.Domain.Tests.Fixtures;
using NerdStore.Catalog.Domain.Tests.Fixtures.Collections;
using NerdStore.Core.Mediator;

namespace NerdStore.Catalog.Domain.Tests.Services
{
    [Collection(nameof(ProductCollection))]
    public class StockServiceTests
    {
        private readonly ProductFixture _productFixture;

        private readonly Mock<IMediatorHandler> _mediatorHandlerMock;
        private readonly Mock<IProductRepository> _productRepositoryMock;

        public StockServiceTests(ProductFixture productFixture)
        {
            _productFixture = productFixture;

            _mediatorHandlerMock = new();
            _productRepositoryMock = new();
        }

        // TODO: Implement StockService Tests

        // Task<bool> AddProductToStockAsync(Guid productId, int quantity);
        // Task<bool> RemoveProductFromStockAsync(Guid productId, int quantity);
        // Task<bool> AddProductsToStockAsync(IEnumerable<AddProductToStockDataTransferObject> products);
        // Task<bool> RemoveProductsFromStockAsync(IEnumerable<RemoveProductFromStockDataTransferObject> products);
        // void Dispose();
    }
}
