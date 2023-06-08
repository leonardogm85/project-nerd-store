using NerdStore.Core.Messages.Common.DomainEvents;

namespace NerdStore.Catalog.Domain.Events
{
    public class ProductWithLowStockEvent : DomainEvent
    {
        public Guid ProductId { get; }
        public int QuantityInStock { get; }

        public ProductWithLowStockEvent(Guid productId, int quantityInStock)
            : base(productId)
        {
            ProductId = productId;
            QuantityInStock = quantityInStock;
        }
    }
}
