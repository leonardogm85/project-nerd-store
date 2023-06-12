using NerdStore.Payments.Domain.Entities;

namespace NerdStore.Payments.Domain.Interfaces.Facades
{
    public interface IPaymentCreditCardFacade : IDisposable
    {
        Task<Transaction> PayOrderAsync(Payment payment);
    }
}
