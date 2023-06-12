using NerdStore.Core.DataTransferObjects;

namespace NerdStore.Catalog.Domain.DataTransferObjects
{
    public class RemoveProductFromStockDataTransferObject : IDataTransferObject
    {
        public Guid ProductId { get; }
        public int Quantity { get; }

        public RemoveProductFromStockDataTransferObject(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
