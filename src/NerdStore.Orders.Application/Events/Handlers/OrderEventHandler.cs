using MediatR;
using NerdStore.Core.Mediator;
using NerdStore.Core.Messages.Common.IntegrationEvents;
using NerdStore.Orders.Application.Commands;

namespace NerdStore.Orders.Application.Events
{
    public sealed class OrderEventHandler :
        INotificationHandler<DraftOrderStartedEvent>,
        INotificationHandler<DraftOrderUpdatedEvent>,
        INotificationHandler<OrderItemAddedEvent>,
        INotificationHandler<OrderItemUpdatedEvent>,
        INotificationHandler<OrderItemRemovedEvent>,
        INotificationHandler<SetVoucherEvent>,
        INotificationHandler<OrderStockRejectedEvent>,
        INotificationHandler<PaymentConfirmedEvent>,
        INotificationHandler<PaymentRejectedEvent>,
        INotificationHandler<OrderFinishedEvent>,
        INotificationHandler<OrderRestartedEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;

        public OrderEventHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public async Task Handle(DraftOrderStartedEvent @event, CancellationToken cancellationToken)
        {
            await Task.CompletedTask; // TODO: Implement DraftOrderStartedEvent Handle
        }

        public async Task Handle(DraftOrderUpdatedEvent @event, CancellationToken cancellationToken)
        {
            await Task.CompletedTask; // TODO: Implement DraftOrderUpdatedEvent Handle
        }

        public async Task Handle(OrderItemAddedEvent @event, CancellationToken cancellationToken)
        {
            await Task.CompletedTask; // TODO: Implement OrderItemAddedEvent Handle
        }

        public async Task Handle(OrderItemUpdatedEvent @event, CancellationToken cancellationToken)
        {
            await Task.CompletedTask; // TODO: Implement OrderItemUpdatedEvent Handle
        }

        public async Task Handle(OrderItemRemovedEvent @event, CancellationToken cancellationToken)
        {
            await Task.CompletedTask; // TODO: Implement OrderItemRemovedEvent Handle
        }

        public async Task Handle(SetVoucherEvent @event, CancellationToken cancellationToken)
        {
            await Task.CompletedTask; // TODO: Implement SetVoucherEvent Handle
        }

        public async Task Handle(OrderStockRejectedEvent @event, CancellationToken cancellationToken)
        {
            await _mediatorHandler.SendCommandAsync(new RestartOrderCommand(
                @event.OrderId,
                @event.ClientId));
        }

        public async Task Handle(PaymentConfirmedEvent @event, CancellationToken cancellationToken)
        {
            await _mediatorHandler.SendCommandAsync(new FinalizeOrderCommand(
                @event.OrderId,
                @event.ClientId));
        }

        public async Task Handle(PaymentRejectedEvent @event, CancellationToken cancellationToken)
        {
            await _mediatorHandler.SendCommandAsync(new CancelOrderCommand(
                @event.OrderId,
                @event.ClientId));
        }

        public async Task Handle(OrderFinishedEvent @event, CancellationToken cancellationToken)
        {
            await Task.CompletedTask; // TODO: Implement OrderFinishedEvent Handle
        }

        public async Task Handle(OrderRestartedEvent @event, CancellationToken cancellationToken)
        {
            await Task.CompletedTask; // TODO: Implement OrderRestartedEvent Handle
        }
    }
}
