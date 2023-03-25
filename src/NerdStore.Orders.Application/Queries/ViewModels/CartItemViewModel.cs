namespace NerdStore.Orders.Application.Queries.ViewModels
{
    public class CartItemViewModel
    {
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public double Price { get; private set; }
        public double Total { get; private set; }

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
