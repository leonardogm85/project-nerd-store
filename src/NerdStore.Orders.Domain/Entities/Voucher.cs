using FluentValidation.Results;
using NerdStore.Core.Domain;

namespace NerdStore.Orders.Domain.Entities
{
    public class Voucher : Entity
    {
        private readonly List<Order> _orders = new();

        public string Code { get; private set; } = null!;
        public double Value { get; private set; }
        public int Quantity { get; private set; }
        public DiscountType DiscountType { get; private set; }
        public DateTime ValidUntil { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UsedAt { get; private set; }
        public bool Used { get; private set; }
        public bool Active { get; private set; }

        public IReadOnlyCollection<Order> Orders
        {
            get
            {
                return _orders.AsReadOnly();
            }
        }

        protected Voucher()
        {
        }

        public Voucher(string code, double value, int quantity, DiscountType discountType, DateTime validUntil, bool active)
        {
            Code = code;
            Value = value;
            Quantity = quantity;
            DiscountType = discountType;
            ValidUntil = validUntil;
            Active = active;

            CreatedAt = DateTime.UtcNow;
        }
    }
}
