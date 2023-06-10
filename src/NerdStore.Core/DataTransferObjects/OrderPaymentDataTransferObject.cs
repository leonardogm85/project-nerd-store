namespace NerdStore.Core.DataTransferObjects
{
    public class OrderPaymentDataTransferObject
    {
        public Guid OrderId { get; }
        public Guid ClientId { get; }
        public double Total { get; }
        public string CardHolder { get; }
        public string CardNumber { get; }
        public string CardExpiresOn { get; }
        public string CardCvv { get; }

        public OrderPaymentDataTransferObject(Guid orderId, Guid clientId, double total, string cardHolder, string cardNumber, string cardExpiresOn, string cardCvv)
        {
            OrderId = orderId;
            ClientId = clientId;
            Total = total;
            CardHolder = cardHolder;
            CardNumber = cardNumber;
            CardExpiresOn = cardExpiresOn;
            CardCvv = cardCvv;
        }
    }
}
