namespace NerdStore.Core.Messages.Common.IntegrationEvents
{
    public class PaymentRejectedEvent : IntegrationEvent
    {
        public Guid OrderId { get; }
        public Guid ClientId { get; }
        public Guid PaymentId { get; }
        public Guid TransactionId { get; }
        public double Amount { get; }

        public PaymentRejectedEvent(Guid orderId, Guid clientId, Guid paymentId, Guid transactionId, double amount)
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
