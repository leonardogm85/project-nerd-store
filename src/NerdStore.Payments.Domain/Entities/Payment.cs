using NerdStore.Core.Domain;

namespace NerdStore.Payments.Domain.Entities
{
    public class Payment : Entity, IAggregateRoot
    {
        private readonly List<Transaction> _transactions = new();

        public Guid OrderId { get; }
        public Guid ClientId { get; }
        public double Amount { get; }
        public string CardHolder { get; }
        public string CardNumber { get; }
        public string CardExpiresOn { get; }
        public string CardCvv { get; }

        public IReadOnlyCollection<Transaction> Transactions
        {
            get
            {
                return _transactions.AsReadOnly();
            }
        }

        public Payment(
            Guid orderId, Guid clientId,
            double amount,
            string cardHolder, string cardNumber, string cardExpiresOn, string cardCvv)
        {
            OrderId = orderId;
            ClientId = clientId;
            Amount = amount;
            CardHolder = cardHolder;
            CardNumber = cardNumber;
            CardExpiresOn = cardExpiresOn;
            CardCvv = cardCvv;
        }
    }
}
