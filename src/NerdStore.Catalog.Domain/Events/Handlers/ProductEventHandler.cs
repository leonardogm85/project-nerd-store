using MediatR;
using NerdStore.Catalog.Domain.Interfaces.Repositories;

namespace NerdStore.Catalog.Domain.Events.Handlers
{
    public sealed class ProductEventHandler : INotificationHandler<ProductWithLowStockEvent>
    {
        private readonly IProductRepository _productRepository;

        public ProductEventHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task Handle(ProductWithLowStockEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask; // TODO: Send a notification email that the quantity in stock is low.
        }
    }
}
