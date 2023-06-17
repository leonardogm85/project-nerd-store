using NerdStore.Core.Domain;

namespace NerdStore.Orders.Domain.Entities
{
    public class Item : Entity
    {
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; } = null!;
        public int Quantity { get; private set; }
        public double Price { get; private set; }

        // TODO: Create Total Property

        public Order? Order { get; private set; }

        protected Item()
        {
        }

        public Item(Guid orderId, Guid productId, string productName, int quantity, double price)
        {
            OrderId = orderId;
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }

        public void ChangeQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public double GetTotal()
        {
            return Quantity * Price;
        }
    }
}
