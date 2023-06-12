using NerdStore.Payments.AntiCorruption.Interfaces.Configuration;
using NerdStore.Payments.AntiCorruption.Interfaces.Gateways;
using NerdStore.Payments.Domain.Entities;
using NerdStore.Payments.Domain.Interfaces.Facades;

namespace NerdStore.Payments.AntiCorruption.Facades
{
    public sealed class PaymentCreditCardFacade : IPaymentCreditCardFacade
    {
        private readonly IPayPalGateway _payPalGateway;
        private readonly IConfigurationManager _configurationManager;

        public PaymentCreditCardFacade(IPayPalGateway payPalGateway, IConfigurationManager configurationManager)
        {
            _payPalGateway = payPalGateway;
            _configurationManager = configurationManager;
        }

        public async Task<Transaction> PayOrderAsync(Payment payment)
        {
            var apiKey = _configurationManager.GetValue("apiKey");
            var encriptionKey = _configurationManager.GetValue("encriptionKey");

            var serviceKey = await _payPalGateway.GetServiceKeyAsync(
                apiKey,
                encriptionKey);

            var cardHashKey = await _payPalGateway.GetCardHashKeyAsync(
                serviceKey,
                payment.CardHolder,
                payment.CardNumber,
                payment.CardExpiresOn,
                payment.CardCvv);

            var confirmed = await _payPalGateway.CommitTransactionAsync(
                cardHashKey,
                payment.OrderId.ToString(),
                payment.Amount);

            // TODO: The transaction object must be returned by gateway

            if (confirmed)
            {
                return new(
                    payment.Id,
                    payment.Amount,
                    TransactionStatus.Confirmed);
            }

            return new(
                payment.Id,
                payment.Amount,
                TransactionStatus.Rejected);
        }

        public void Dispose()
        {
            _payPalGateway.Dispose();
            _configurationManager.Dispose();
        }
    }
}
