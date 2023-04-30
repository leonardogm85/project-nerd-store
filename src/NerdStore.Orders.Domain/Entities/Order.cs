using NerdStore.Core.Domain;

namespace NerdStore.Orders.Domain.Entities
{
    public class Order : Entity, IAggregateRoot
    {
        private readonly List<Item> _items;

        public Guid ClientId { get; private set; }
        public Guid? VoucherId { get; private set; }
        public int Code { get; private set; }
        public bool VoucherUsed { get; private set; }
        public double Discount { get; private set; }
        public double Total { get; private set; }
        public Status Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Voucher? Voucher { get; private set; }

        public IReadOnlyCollection<Item> Items
        {
            get
            {
                return _items.AsReadOnly();
            }
        }

        protected Order()
        {
        }

        protected Order(Guid clientId)
        {
            ClientId = clientId;

            CreatedAt = DateTime.UtcNow;

            _items = new();

            DraftOrder();
        }

        public void DraftOrder()
        {
            Status = Status.Draft;
        }

        public void StartOrder()
        {
            Status = Status.Started;
        }

        public void FinalizeOrder()
        {
            Status = Status.Paid;
        }

        public void CancelOrder()
        {
            Status = Status.Canceled;
        }

        public void UseVoucher(Voucher voucher)
        {
            VoucherId = voucher.Id;

            VoucherUsed = true;
        }

        public void AddItem(Item item)
        {
            if (!item.IsValid())
            {
                return;
            }

            var existingItem = _items.FirstOrDefault(i => i.ProductId == item.ProductId);

            if (existingItem is not null)
            {
                existingItem.AddQuantity(item.Quantity);

                item = existingItem;

                _items.Remove(existingItem);
            }

            _items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            if (!item.IsValid())
            {
                return;
            }

            var existingItem = Items.FirstOrDefault(i => i.ProductId == item.ProductId)
                ??
                throw new DomainException("The order does not have this item.");

            _items.Remove(existingItem);
            _items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            if (!item.IsValid())
            {
                return;
            }

            var existingItem = _items.FirstOrDefault(i => i.ProductId == item.ProductId)
                ??
                throw new DomainException("The order does not have this item.");

            _items.Remove(existingItem);
        }

        public void CalculateTotal(Voucher voucher)
        {
            var total = _items.Sum(i => i.GetTotal());

            if (VoucherUsed)
            {
                Discount = voucher!.DiscountType == DiscountType.Percentage
                    ? total * voucher.Value / 100
                    : voucher.Value;

                Total = total < Discount
                    ? 0
                    : total;
            }
            else
            {
                Discount = 0;
                Total = total;
            }
        }
    }
}
