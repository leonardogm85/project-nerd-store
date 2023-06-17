using NerdStore.Core.Messages;

namespace NerdStore.Orders.Application.Events
{
    public class OrderRestartedEvent : Event
    {
        public Guid OrderId { get; }
        public Guid ClientId { get; }

        public OrderRestartedEvent(Guid orderId, Guid clientId)
            : base(orderId)
        {
            OrderId = orderId;
            ClientId = clientId;
        }
    }
}
