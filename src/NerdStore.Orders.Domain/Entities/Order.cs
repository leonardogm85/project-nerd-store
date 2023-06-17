using FluentValidation.Results;
using NerdStore.Core.Domain;
using NerdStore.Orders.Domain.Validations;

namespace NerdStore.Orders.Domain.Entities
{
    public class Order : Entity, IAggregateRoot
    {
        private readonly List<Item> _items = new();

        public Guid ClientId { get; private set; }
        public Guid? VoucherId { get; private set; }
        public int Code { get; private set; }
        public bool VoucherUsed { get; private set; }
        public double Discount { get; private set; }
        public double Total { get; private set; }
        public Status Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // TODO: Create Subtotal Property

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

        public Order(Guid clientId)
        {
            ClientId = clientId;
            CreatedAt = DateTime.UtcNow;
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

        public ValidationResult UseVoucher(Voucher voucher)
        {
            var validationResult = new UseVoucherValidation().Validate(voucher);

            if (validationResult.IsValid)
            {
                Voucher = voucher;
                VoucherId = voucher.Id;
                VoucherUsed = true;

                CalculateTotal();
            }

            return validationResult;
        }

        public void AddItem(Item item)
        {
            var existingItem = GetItemByProductId(item.ProductId);

            if (existingItem is null)
            {
                _items.Add(item);
            }
            else
            {
                existingItem.AddQuantity(item.Quantity);
            }

            CalculateTotal();
        }

        public void UpdateItem(Item item)
        {
            var existingItem = GetItemByProductId(item.ProductId)
                ??
                throw new DomainException("The order does not have this item.");

            existingItem.ChangeQuantity(item.Quantity);

            CalculateTotal();
        }

        public void RemoveItem(Item item)
        {
            var existingItem = GetItemByProductId(item.ProductId)
                ??
                throw new DomainException("The order does not have this item.");

            _items.Remove(existingItem);

            CalculateTotal();
        }

        public Item? GetItemByProductId(Guid productId)
        {
            return _items.FirstOrDefault(i => i.ProductId == productId);
        }

        private void CalculateTotal()
        {
            var total = _items.Sum(i => i.GetTotal());

            if (VoucherUsed)
            {
                Discount = Voucher!.DiscountType == DiscountType.Percentage
                    ? total * Voucher.Value / 100
                    : Voucher.Value;

                Total = total < Discount
                    ? 0
                    : total - Discount;
            }
            else
            {
                Discount = 0;
                Total = total;
            }
        }
    }
}
