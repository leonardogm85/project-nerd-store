using NerdStore.Core.Messages;

namespace NerdStore.Orders.Application.Events
{
    public class DraftOrderStartedEvent : Event
    {
        public Guid OrderId { get; private set; }
        public Guid ClientId { get; private set; }

        public DraftOrderStartedEvent(Guid orderId, Guid clientId) : base(orderId)
        {
            OrderId = orderId;
            ClientId = clientId;
        }
    }
}
