namespace NerdStore.Catalog.Domain.DataTransferObjects
{
    public class RemoveProductFromStockDataTransferObject
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
