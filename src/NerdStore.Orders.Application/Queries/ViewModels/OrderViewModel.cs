namespace NerdStore.Orders.Application.Queries.ViewModels
{
    public class OrderViewModel
    {
        public int Code { get; private set; }
        public double Total { get; private set; }
        public int Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public OrderViewModel(int code, double total, int status, DateTime createdAt)
        {
            Code = code;
            Total = total;
            Status = status;
            CreatedAt = createdAt;
        }
    }
}
