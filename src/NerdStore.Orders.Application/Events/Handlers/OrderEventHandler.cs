using MediatR;
using NerdStore.Core.Messages.Common.IntegrationEvents;

namespace NerdStore.Orders.Application.Events
{
    public class OrderEventHandler :
        INotificationHandler<DraftOrderStartedEvent>,
        INotificationHandler<DraftOrderUpdatedEvent>,
        INotificationHandler<OrderItemAddedEvent>,
        INotificationHandler<OrderItemUpdatedEvent>,
        INotificationHandler<OrderItemRemovedEvent>,
        INotificationHandler<SetVoucherEvent>,
        INotificationHandler<OrderStockRejectedEvent>
    {
        public Task Handle(DraftOrderStartedEvent @event, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DraftOrderUpdatedEvent @event, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrderItemAddedEvent @event, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrderItemUpdatedEvent @event, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrderItemRemovedEvent @event, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(SetVoucherEvent @event, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrderStockRejectedEvent @event, CancellationToken cancellationToken)
        {
            // TODO: Cancel order

            return Task.CompletedTask;
        }
    }
}
