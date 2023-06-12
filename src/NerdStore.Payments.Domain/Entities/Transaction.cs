using NerdStore.Core.Domain;

namespace NerdStore.Payments.Domain.Entities
{
    public class Transaction : Entity
    {
        public Guid PaymentId { get; }
        public double Amount { get; }
        public TransactionStatus Status { get; }

        public Payment? Payment { get; }

        public Transaction(Guid paymentId, double amount, TransactionStatus status)
        {
            PaymentId = paymentId;
            Amount = amount;
            Status = status;
        }
    }
}
