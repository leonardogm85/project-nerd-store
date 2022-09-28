using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalog.Domain.Events
{
    public class ProductWithLowStockEvent : DomainEvent
    {
        public int QuantityInStock { get; private set; }

        public ProductWithLowStockEvent(Guid aggregateId, int quantityInStock) : base(aggregateId)
        {
            QuantityInStock = quantityInStock;
        }
    }
}
