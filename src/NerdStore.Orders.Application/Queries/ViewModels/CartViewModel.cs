namespace NerdStore.Orders.Application.Queries.ViewModels
{
    public class CartViewModel
    {
        public Guid OrderId { get; }
        public Guid ClientId { get; }
        public double Subtotal { get; }
        public double Discount { get; }
        public double Total { get; }
        public string? VoucherCode { get; }

        public List<CartItemViewModel> Items { get; } = new();

        public CartPaymentViewModel? Payment { get; init; }

        public CartViewModel(Guid orderId, Guid clientId, double subtotal, double discount, double total, string? voucherCode)
        {
            OrderId = orderId;
            ClientId = clientId;
            Subtotal = subtotal;
            Discount = discount;
            Total = total;
            VoucherCode = voucherCode;
        }
    }
}
