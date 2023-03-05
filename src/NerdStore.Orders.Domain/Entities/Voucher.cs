using NerdStore.Core.DomainObjects;

namespace NerdStore.Orders.Domain.Entities
{
    public class Voucher : Entity
    {
        public string Code { get; private set; }
        public double Value { get; private set; }
        public int Quantity { get; private set; }
        public DiscountType DiscountType { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime ValidUntil { get; private set; }
        public DateTime? UsedAt { get; private set; }
        public bool Active { get; private set; }
        public bool Used { get; private set; }

        public IEnumerable<Order> Orders { get; private set; }
    }
}
