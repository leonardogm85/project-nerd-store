using NerdStore.Core.DataTransferObjects;
using NerdStore.Core.Mediator;
using NerdStore.Core.Messages.Common.DomainNotifications;
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
                await _mediatorHandler.PublishEventAsync(new PaymentConfirmedEvent(
                    payment.OrderId,
                    payment.ClientId,
                    payment.Id,
                    transaction.Id,
                    payment.Amount));

                _paymentRepository.AddPayment(payment);
                _paymentRepository.AddTransaction(transaction);

                await _paymentRepository.UnitOfWork.CommitAsync();
            }
            else
            {
                await _mediatorHandler.PublishEventAsync(new PaymentRejectedEvent(
                    payment.OrderId,
                    payment.ClientId,
                    payment.Id,
                    transaction.Id,
                    payment.Amount));

                await _mediatorHandler.PublishDomainNotificationAsync(new DomainNotification(nameof(Payment), "Payment rejected."));
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
