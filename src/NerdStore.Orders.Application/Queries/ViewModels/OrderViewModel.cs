using System.Diagnostics.CodeAnalysis;

namespace NerdStore.Orders.Application.Queries.ViewModels
{
    public class OrderViewModel
    {
        public required Guid OrderId { get; init; }
        public required int Code { get; init; }
        public required double Total { get; init; }
        public required int Status { get; init; }
        public required DateTime CreatedAt { get; init; }

        public OrderViewModel()
        {
        }

        [SetsRequiredMembers]
        public OrderViewModel(Guid orderId, int code, double total, int status, DateTime createdAt)
        {
            OrderId = orderId;
            Code = code;
            Total = total;
            Status = status;
            CreatedAt = createdAt;
        }
    }
}
