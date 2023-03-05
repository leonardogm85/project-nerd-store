using NerdStore.Core.DomainObjects;

namespace NerdStore.Orders.Domain.Entities
{
    public class Order : Entity, IAggregateRoot
    {
        public Guid ClientId { get; private set; }
        public Guid? VoucherId { get; private set; }
        public int Code { get; private set; }
        public bool VoucherUsed { get; private set; }
        public double Discount { get; private set; }
        public double Total { get; private set; }
        public Status Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public virtual Voucher? Voucher { get; private set; }

        public IList<Item> Items { get; private set; }

        protected Order()
        {
        }

        public void SetVoucher(Voucher voucher)
        {
            Voucher = voucher;
            VoucherUsed = true;
            CalculateTotal();
        }

        public void CalculateTotal()
        {
            var total = Items.Sum(i => i.GetTotal());

            if (VoucherUsed)
            {
                Discount = Voucher!.DiscountType == DiscountType.Percentage
                    ? total * Voucher.Value / 100
                    : Voucher.Value;

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

        public void AddItem(Item item)
        {
            if (!item.IsValid())
            {
                return;
            }

            var existingItem = Items.FirstOrDefault(i => i.ProductId == item.ProductId);

            if (existingItem is not null)
            {
                existingItem.AddQuantity(item.Quantity);

                item = existingItem;

                Items.Remove(existingItem);
            }

            Items.Add(item);
            CalculateTotal();
        }

        public void UpdateItem(Item item)
        {
            if (!item.IsValid())
            {
                return;
            }

            var existingItem = Items.FirstOrDefault(i => i.ProductId == item.ProductId);

            if (existingItem is null)
            {
                throw new DomainException("The order does not have this item.");
            }

            Items.Remove(existingItem);
            Items.Add(item);
            CalculateTotal();
        }

        public void RemoveItem(Item item)
        {
            if (!item.IsValid())
            {
                return;
            }

            var existingItem = Items.FirstOrDefault(i => i.ProductId == item.ProductId);

            if (existingItem is null)
            {
                throw new DomainException("The order does not have this item.");
            }

            Items.Remove(existingItem);
            CalculateTotal();
        }

        public void DraftOrder() => Status = Status.Draft;

        public void StartOrder() => Status = Status.Started;

        public void FinalizeOrder() => Status = Status.Paid;

        public void CancelOrder() => Status = Status.Canceled;

        public static class OrderFactory
        {
            public static Order NewDraftOrder(Guid clientId)
            {
                var order = new Order
                {
                    ClientId = clientId,
                    CreatedAt = DateTime.Now,
                    Items = new List<Item>()
                };

                order.DraftOrder();

                return order;
            }
        }
    }
}
