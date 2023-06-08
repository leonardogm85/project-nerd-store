using NerdStore.Core.Messages;

namespace NerdStore.Orders.Application.Events
{
    public class OrderItemRemovedEvent : Event
    {
        public Guid OrderId { get; }
        public Guid ClientId { get; }
        public Guid ProductId { get; }

        public OrderItemRemovedEvent(Guid orderId, Guid clientId, Guid productId)
            : base(orderId)
        {
            OrderId = orderId;
            ClientId = clientId;
            ProductId = productId;
        }
    }
}
