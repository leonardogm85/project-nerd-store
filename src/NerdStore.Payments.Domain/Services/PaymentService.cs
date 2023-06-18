using NerdStore.Core.DataTransferObjects;
using NerdStore.Core.Mediator;
using NerdStore.Core.Messages.Common.IntegrationEvents;
using NerdStore.Payments.Domain.Entities;
using NerdStore.Payments.Domain.Interfaces.Facades;
using NerdStore.Payments.Domain.Interfaces.Repositories;
using NerdStore.Payments.Domain.Interfaces.Services;

namespace NerdStore.Payments.Domain.Services
{
    public sealed class PaymentService : IPaymentService
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentCreditCardFacade _paymentCreditCardFacade;

        public PaymentService(IMediatorHandler mediatorHandler, IPaymentRepository paymentRepository, IPaymentCreditCardFacade paymentCreditCardFacade)
        {
            _mediatorHandler = mediatorHandler;
            _paymentRepository = paymentRepository;
            _paymentCreditCardFacade = paymentCreditCardFacade;
        }

        public async Task<Transaction> PayOrderAsync(OrderPaymentDataTransferObject orderPayment)
        {
            var payment = new Payment(
                orderPayment.OrderId,
                orderPayment.ClientId,
                orderPayment.Amount,
                orderPayment.CardHolder,
                orderPayment.CardNumber,
                orderPayment.CardExpiresOn,
                orderPayment.CardCvv);

            var transaction = await _paymentCreditCardFacade.PayOrderAsync(payment);

            if (transaction.Status == TransactionStatus.Confirmed)
            {
                _paymentRepository.AddPayment(payment);
                _paymentRepository.AddTransaction(transaction);

                if (await _paymentRepository.UnitOfWork.CommitAsync())
                {
                    await _mediatorHandler.PublishEventAsync(new PaymentConfirmedEvent(
                        payment.OrderId,
                        payment.ClientId,
                        payment.Id,
                        transaction.Id,
                        payment.Amount));
                }
            }
            else
            {
                await _mediatorHandler.PublishDomainNotificationAsync(new(nameof(Payment), "Payment rejected."));

                await _mediatorHandler.PublishEventAsync(new PaymentRejectedEvent(
                    payment.OrderId,
                    payment.ClientId,
                    payment.Id,
                    transaction.Id,
                    payment.Amount));
            }

            return transaction;
        }

        public void Dispose()
        {
            _paymentRepository.Dispose();
            _paymentCreditCardFacade.Dispose();
        }
    }
}
