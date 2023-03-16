using NerdStore.Core.Messages.CommonMessages.DomainEvents;

namespace NerdStore.Catalog.Domain.Events
{
    public class ProductWithLowStockEvent : DomainEvent
    {
        public Guid ProductId { get; private set; }
        public int QuantityInStock { get; private set; }

        public ProductWithLowStockEvent(Guid productId, int quantityInStock) : base(productId)
        {
            ProductId = productId;
            QuantityInStock = quantityInStock;
        }
    }
}
