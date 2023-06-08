using MediatR;

namespace NerdStore.Orders.Application.Events
{
    public class OrderEventHandler :
        INotificationHandler<DraftOrderStartedEvent>,
        INotificationHandler<OrderUpdatedEvent>,
        INotificationHandler<OrderItemAddedEvent>,
        INotificationHandler<OrderItemUpdatedEvent>,
        INotificationHandler<OrderItemRemovedEvent>,
        INotificationHandler<SetVoucherEvent>
    {
        public Task Handle(DraftOrderStartedEvent @event, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrderUpdatedEvent @event, CancellationToken cancellationToken)
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
    }
}
