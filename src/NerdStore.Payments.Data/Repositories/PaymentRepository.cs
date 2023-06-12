using NerdStore.Core.Data;
using NerdStore.Payments.Data.Context;
using NerdStore.Payments.Domain.Entities;
using NerdStore.Payments.Domain.Interfaces.Repositories;

namespace NerdStore.Payments.Data.Repositories
{
    public sealed class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public PaymentRepository(PaymentContext context)
        {
            _context = context;
        }

        public void AddPayment(Payment payment)
        {
            _context.Payments.Add(payment);
        }

        public void AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
