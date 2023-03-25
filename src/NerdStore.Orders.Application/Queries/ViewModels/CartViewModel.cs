namespace NerdStore.Orders.Application.Queries.ViewModels
{
    public class CartViewModel
    {
        public CartViewModel(Guid orderId, Guid clientId, double subtotal, double discount, double total, string? voucherCode)
        {
            OrderId = orderId;
            ClientId = clientId;
            Subtotal = subtotal;
            Discount = discount;
            Total = total;
            VoucherCode = voucherCode;
        }

        public Guid OrderId { get; private set; }
        public Guid ClientId { get; private set; }
        public double Subtotal { get; private set; }
        public double Discount { get; private set; }
        public double Total { get; private set; }
        public string? VoucherCode { get; private set; }

        public ICollection<CartItemViewModel> Items { get; private set; } = new List<CartItemViewModel>();

        public CartPaymentViewModel? Payment { get; private set; }
    }
}
