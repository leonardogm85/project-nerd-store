using NerdStore.Core.Messages;

namespace NerdStore.Orders.Application.Events
{
    public class OrderFinishedEvent : Event
    {
        public Guid OrderId { get; }
        public Guid ClientId { get; }

        public OrderFinishedEvent(Guid orderId, Guid clientId)
            : base(orderId)
        {
            OrderId = orderId;
            ClientId = clientId;
        }
    }
}
