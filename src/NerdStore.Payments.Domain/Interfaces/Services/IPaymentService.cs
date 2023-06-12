using NerdStore.Core.DataTransferObjects;
using NerdStore.Payments.Domain.Entities;

namespace NerdStore.Payments.Domain.Interfaces.Services
{
    public interface IPaymentService : IDisposable
    {
        Task<Transaction> PayOrderAsync(OrderPaymentDataTransferObject orderPayment);
    }
}
