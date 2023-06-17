using System.Diagnostics.CodeAnalysis;

namespace NerdStore.Orders.Application.Queries.ViewModels
{
    public class CartItemViewModel
    {
        public required Guid ProductId { get; init; }
        public required string ProductName { get; init; }
        public required int Quantity { get; init; }
        public required double Price { get; init; }
        public required double Total { get; init; }

        public CartItemViewModel()
        {
        }

        [SetsRequiredMembers]
        public CartItemViewModel(Guid productId, string productName, int quantity, double price, double total)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            Total = total;
        }
    }
}
