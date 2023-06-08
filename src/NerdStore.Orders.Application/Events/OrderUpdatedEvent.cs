using NerdStore.Core.Messages;

namespace NerdStore.Orders.Application.Events
{
    public class OrderUpdatedEvent : Event
    {
        public Guid OrderId { get; }
        public Guid ClientId { get; }
        public double Total { get; }

        public OrderUpdatedEvent(Guid orderId, Guid clientId, double total)
            : base(orderId)
        {
            OrderId = orderId;
            ClientId = clientId;
            Total = total;
        }
    }
}
