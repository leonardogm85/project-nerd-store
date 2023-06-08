namespace NerdStore.Orders.Application.Queries.ViewModels
{
    public class OrderViewModel
    {
        public int Code { get; }
        public double Total { get; }
        public int Status { get; }
        public DateTime CreatedAt { get; }

        public OrderViewModel(int code, double total, int status, DateTime createdAt)
        {
            Code = code;
            Total = total;
            Status = status;
            CreatedAt = createdAt;
        }
    }
}
