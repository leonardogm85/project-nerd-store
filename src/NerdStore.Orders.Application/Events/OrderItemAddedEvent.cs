using NerdStore.Core.Messages;

namespace NerdStore.Orders.Application.Events
{
    public class OrderItemAddedEvent : Event
    {
        public Guid OrderId { get; private set; }
        public Guid ClientId { get; private set; }
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public double Price { get; private set; }

        public OrderItemAddedEvent(Guid orderId, Guid clientId, Guid productId, string productName, int quantity, double price) : base(orderId)
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
