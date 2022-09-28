using MediatR;
using NerdStore.Catalog.Domain.Events;
using NerdStore.Catalog.Domain.Interfaces.Repositories;

namespace NerdStore.Catalog.Domain.EventHandlers
{
    public class ProductEventHandler : INotificationHandler<ProductWithLowStockEvent>
    {
        private readonly IProductRepository _productRepository;

        public ProductEventHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(ProductWithLowStockEvent notification, CancellationToken cancellationToken)
        {
            // TODO: Send a notification e-mail informing you that the quantity in stock is low.
        }
    }
}
