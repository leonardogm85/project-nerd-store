namespace NerdStore.Orders.Application.Queries.ViewModels
{
    public class CartItemViewModel
    {
        public Guid ProductId { get; }
        public string ProductName { get; }
        public int Quantity { get; }
        public double Price { get; }
        public double Total { get; }

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
