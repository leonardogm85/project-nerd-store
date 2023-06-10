using NerdStore.Core.Messages;

namespace NerdStore.Orders.Application.Events
{
    public class DraftOrderUpdatedEvent : Event
    {
        public Guid OrderId { get; }
        public Guid ClientId { get; }
        public double Total { get; }

        public DraftOrderUpdatedEvent(Guid orderId, Guid clientId, double total)
            : base(orderId)
        {
            OrderId = orderId;
            ClientId = clientId;
            Total = total;
        }
    }
}
