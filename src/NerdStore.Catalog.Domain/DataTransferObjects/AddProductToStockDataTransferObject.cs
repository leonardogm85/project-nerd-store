using NerdStore.Core.DataTransferObjects;

namespace NerdStore.Catalog.Domain.DataTransferObjects
{
    public class AddProductToStockDataTransferObject : IDataTransferObject
    {
        public Guid ProductId { get; }
        public int Quantity { get; }

        public AddProductToStockDataTransferObject(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
