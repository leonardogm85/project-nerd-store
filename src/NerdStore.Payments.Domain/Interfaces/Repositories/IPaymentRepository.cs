using NerdStore.Core.Data;
using NerdStore.Payments.Domain.Entities;

namespace NerdStore.Payments.Domain.Interfaces.Repositories
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        void AddPayment(Payment payment);
        void AddTransaction(Transaction transaction);
    }
}
