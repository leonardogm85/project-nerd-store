using NerdStore.Core.DataTransferObjects;

namespace NerdStore.Payments.Domain.DataTransferObjects
{
    public class OrderDataTransferObject : IDataTransferObject
    {
        public Guid OrderId { get; }
        public Guid ClientId { get; }
        public double Total { get; }
        public IEnumerable<ProductDataTransferObject> Products { get; }

        public OrderDataTransferObject(Guid orderId, Guid clientId, double total, IEnumerable<ProductDataTransferObject> products)
        {
            OrderId = orderId;
            ClientId = clientId;
            Total = total;
            Products = products;
        }
    }
}
