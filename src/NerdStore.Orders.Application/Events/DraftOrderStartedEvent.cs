using NerdStore.Core.Messages;

namespace NerdStore.Orders.Application.Events
{
    public class DraftOrderStartedEvent : Event
    {
        public Guid OrderId { get; }
        public Guid ClientId { get; }
        public double Total { get; }

        public DraftOrderStartedEvent(Guid orderId, Guid clientId, double total)
            : base(orderId)
        {
            OrderId = orderId;
            ClientId = clientId;
            Total = total;
        }
    }
}
