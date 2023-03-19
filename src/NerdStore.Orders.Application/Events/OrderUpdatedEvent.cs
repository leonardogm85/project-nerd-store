using NerdStore.Core.Messages;

namespace NerdStore.Orders.Application.Events
{
    public class OrderUpdatedEvent : Event
    {
        public Guid OrderId { get; private set; }
        public Guid ClientId { get; private set; }
        public double Total { get; private set; }

        public OrderUpdatedEvent(Guid orderId, Guid clientId, double total) : base(orderId)
        {
            OrderId = orderId;
            ClientId = clientId;
            Total = total;
        }
    }
}
