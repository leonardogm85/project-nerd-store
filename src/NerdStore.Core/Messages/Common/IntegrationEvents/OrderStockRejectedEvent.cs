namespace NerdStore.Core.Messages.Common.IntegrationEvents
{
    public class OrderStockRejectedEvent : IntegrationEvent
    {
        public Guid OrderId { get; }
        public Guid ClientId { get; }

        public OrderStockRejectedEvent(Guid orderId, Guid clientId)
            : base(orderId)
        {
            OrderId = orderId;
            ClientId = clientId;
        }
    }
}
