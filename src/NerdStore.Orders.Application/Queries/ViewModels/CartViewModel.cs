using System.Diagnostics.CodeAnalysis;

namespace NerdStore.Orders.Application.Queries.ViewModels
{
    public class CartViewModel
    {
        public required Guid OrderId { get; init; }
        public required Guid ClientId { get; init; }
        public required double Subtotal { get; init; }
        public required double Discount { get; init; }
        public required double Total { get; init; }
        public string? VoucherCode { get; init; }
        public required IEnumerable<CartItemViewModel> Items { get; init; }

        public CartViewModel()
        {
        }

        [SetsRequiredMembers]
        public CartViewModel(Guid orderId, Guid clientId, double subtotal, double discount, double total, string? voucherCode, IEnumerable<CartItemViewModel> items)
        {
            OrderId = orderId;
            ClientId = clientId;
            Subtotal = subtotal;
            Discount = discount;
            Total = total;
            VoucherCode = voucherCode;
            Items = items;
        }
    }
}
