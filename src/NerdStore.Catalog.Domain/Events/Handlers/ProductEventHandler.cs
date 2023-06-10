using MediatR;
using NerdStore.Catalog.Domain.DataTransferObjects;
using NerdStore.Catalog.Domain.Interfaces.Repositories;
using NerdStore.Catalog.Domain.Interfaces.Services;
using NerdStore.Core.Mediator;
using NerdStore.Core.Messages;
using NerdStore.Core.Messages.Common.IntegrationEvents;

namespace NerdStore.Catalog.Domain.Events.Handlers
{
    public sealed class ProductEventHandler :
        INotificationHandler<ProductWithLowStockEvent>,
        INotificationHandler<OrderStartedEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IProductRepository _productRepository;
        private readonly IStockService _stockService;

        public ProductEventHandler(IMediatorHandler mediatorHandler, IProductRepository productRepository, IStockService stockService)
        {
            _mediatorHandler = mediatorHandler;
            _productRepository = productRepository;
            _stockService = stockService;
        }

        public Task Handle(ProductWithLowStockEvent @event, CancellationToken cancellationToken)
        {
            return Task.CompletedTask; // TODO: Send a notification email that the quantity in stock is low.
        }

        public async Task Handle(OrderStartedEvent @event, CancellationToken cancellationToken)
        {
            var products = new List<RemoveProductFromStockDataTransferObject>();

            foreach (var item in @event.Items)
            {
                products.Add(new(item.ProductId, item.Quantity));
            }

            if (await _stockService.RemoveProductsFromStockAsync(products))
            {
                await _mediatorHandler.PublishEventAsync(new OrderStockConfirmedEvent(
                    @event.OrderId,
                    @event.ClientId,
                    @event.Total,
                    @event.CardHolder,
                    @event.CardNumber,
                    @event.CardExpiresOn,
                    @event.CardCvv,
                    @event.Items));
            }
            else
            {
                await _mediatorHandler.PublishEventAsync(new OrderStockRejectedEvent(
                    @event.OrderId,
                    @event.ClientId));
            }
        }

        // TODO: OrderCanceledEvent
    }
}
