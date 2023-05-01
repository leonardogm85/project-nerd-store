using MediatR;

namespace NerdStore.Orders.Application.Events
{
    public class OrderEventHandler :
        INotificationHandler<DraftOrderStartedEvent>,
        INotificationHandler<OrderUpdatedEvent>,
        INotificationHandler<OrderItemAddedEvent>
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
    }
}
