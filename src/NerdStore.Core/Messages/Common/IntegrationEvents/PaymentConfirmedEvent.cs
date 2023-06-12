namespace NerdStore.Core.Messages.Common.IntegrationEvents
{
    public class PaymentConfirmedEvent : IntegrationEvent
    {
        public Guid OrderId { get; }
        public Guid ClientId { get; }
        public Guid PaymentId { get; }
        public Guid TransactionId { get; }
        public double Amount { get; }

        public PaymentConfirmedEvent(Guid orderId, Guid clientId, Guid paymentId, Guid transactionId, double amount)
            : base(orderId)
        {
            OrderId = orderId;
            ClientId = clientId;
            PaymentId = paymentId;
            TransactionId = transactionId;
            Amount = amount;
        }
    }
}
