namespace NerdStore.Orders.Domain.Entities
{
    public enum Status
    {
        Draft = 1,
        Started = 2,
        Paid = 3,
        Delivered = 4,
        Canceled = 5,
    }
}
