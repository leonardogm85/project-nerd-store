using NerdStore.Core.DataTransferObjects;

namespace NerdStore.Core.Messages.Common.IntegrationEvents
{
    public class OrderCanceledEvent : IntegrationEvent
    {
        public Guid OrderId { get; }
        public Guid ClientId { get; }
        public IEnumerable<OrderItemDataTransferObject> Items { get; }

        public OrderCanceledEvent(Guid orderId, Guid clientId, IEnumerable<OrderItemDataTransferObject> items)
            : base(orderId)
        {
            OrderId = orderId;
            ClientId = clientId;
            Items = items;
        }
    }
}
