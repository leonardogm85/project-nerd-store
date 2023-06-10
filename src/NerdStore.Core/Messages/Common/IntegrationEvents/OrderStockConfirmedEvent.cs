using NerdStore.Core.DataTransferObjects;

namespace NerdStore.Core.Messages.Common.IntegrationEvents
{
    public class OrderStockConfirmedEvent : IntegrationEvent
    {
        public Guid OrderId { get; }
        public Guid ClientId { get; }
        public double Total { get; }
        public string CardHolder { get; }
        public string CardNumber { get; }
        public string CardExpiresOn { get; }
        public string CardCvv { get; }
        public IEnumerable<OrderItemDataTransferObject> Items { get; }

        public OrderStockConfirmedEvent(
                Guid orderId, Guid clientId,
                double total,
                string cardHolder, string cardNumber, string cardExpiresOn, string cardCvv,
                IEnumerable<OrderItemDataTransferObject> items)
            : base(orderId)
        {
            OrderId = orderId;
            ClientId = clientId;
            Total = total;
            CardHolder = cardHolder;
            CardNumber = cardNumber;
            CardExpiresOn = cardExpiresOn;
            CardCvv = cardCvv;
            Items = items;
        }
    }
}
