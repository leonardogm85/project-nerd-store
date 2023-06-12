using MediatR;
using NerdStore.Core.DataTransferObjects;
using NerdStore.Core.Messages.Common.IntegrationEvents;
using NerdStore.Payments.Domain.Interfaces.Services;

namespace NerdStore.Payments.Domain.Events.Handlers
{
    public class PaymentEventHandler : INotificationHandler<OrderStockConfirmedEvent>
    {
        private readonly IPaymentService _paymentService;

        public PaymentEventHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task Handle(OrderStockConfirmedEvent @event, CancellationToken cancellationToken)
        {
            var orderPayment = new OrderPaymentDataTransferObject(
                @event.OrderId,
                @event.ClientId,
                @event.Total,
                @event.CardHolder,
                @event.CardNumber,
                @event.CardExpiresOn,
                @event.CardCvv);

            await _paymentService.PayOrderAsync(orderPayment);
        }
    }
}
