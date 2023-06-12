using NerdStore.Core.DataTransferObjects;

namespace NerdStore.Payments.Domain.DataTransferObjects
{
    public class ProductDataTransferObject : IDataTransferObject
    {
        public Guid ProductId { get; }
        public string ProductName { get; }
        public int Quantity { get; }
        public double Price { get; }

        public ProductDataTransferObject(Guid productId, string productName, int quantity, double price)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }
    }
}
