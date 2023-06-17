using MediatR;
using NerdStore.Catalog.Domain.DataTransferObjects;
using NerdStore.Catalog.Domain.Interfaces.Services;
using NerdStore.Core.Mediator;
using NerdStore.Core.Messages.Common.IntegrationEvents;

namespace NerdStore.Catalog.Domain.Events.Handlers
{
    public sealed class ProductEventHandler :
        INotificationHandler<ProductWithLowStockEvent>,
        INotificationHandler<OrderStartedEvent>,
        INotificationHandler<OrderCanceledEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IStockService _stockService;

        public ProductEventHandler(IMediatorHandler mediatorHandler, IStockService stockService)
        {
            _mediatorHandler = mediatorHandler;
            _stockService = stockService;
        }

        public Task Handle(ProductWithLowStockEvent @event, CancellationToken cancellationToken)
        {
            return Task.CompletedTask; // TODO: Send a notification email that the quantity in stock is low
        }

        public async Task Handle(OrderStartedEvent @event, CancellationToken cancellationToken)
        {
            var products = @event.Items.Select(item => new RemoveProductFromStockDataTransferObject(
                item.ProductId,
                item.Quantity));

            if (await _stockService.RemoveProductsFromStockAsync(products))
            {
                await _mediatorHandler.PublishIntegrationEventAsync(new OrderStockConfirmedEvent(
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
                await _mediatorHandler.PublishIntegrationEventAsync(new OrderStockRejectedEvent(
                    @event.OrderId,
                    @event.ClientId));
            }
        }

        public async Task Handle(OrderCanceledEvent @event, CancellationToken cancellationToken)
        {
            var products = @event.Items.Select(item => new AddProductToStockDataTransferObject(
                item.ProductId,
                item.Quantity));

            await _stockService.AddProductsToStockAsync(products);
        }
    }
}
