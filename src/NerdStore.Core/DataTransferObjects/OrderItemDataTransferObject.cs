namespace NerdStore.Core.DataTransferObjects
{
    public class OrderItemDataTransferObject : IDataTransferObject
    {
        public Guid ProductId { get; }
        public int Quantity { get; }
        public double Price { get; }

        public OrderItemDataTransferObject(Guid productId, int quantity, double price)
        {
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }
    }
}
