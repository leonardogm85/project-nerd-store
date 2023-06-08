using NerdStore.Core.Messages;

namespace NerdStore.Orders.Application.Events
{
    public class OrderItemUpdatedEvent : Event
    {
        public Guid OrderId { get; }
        public Guid ClientId { get; }
        public Guid ProductId { get; }
        public string ProductName { get; }
        public int Quantity { get; }
        public double Price { get; }

        public OrderItemUpdatedEvent(Guid orderId, Guid clientId, Guid productId, string productName, int quantity, double price)
            : base(orderId)
        {
            OrderId = orderId;
            ClientId = clientId;
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }
    }
}
