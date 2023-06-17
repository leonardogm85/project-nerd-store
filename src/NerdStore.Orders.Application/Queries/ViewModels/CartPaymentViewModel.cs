using System.Diagnostics.CodeAnalysis;

namespace NerdStore.Orders.Application.Queries.ViewModels
{
    public class CartPaymentViewModel
    {
        public required string CardHolder { get; init; }
        public required string CardNumber { get; init; }
        public required string CardExpiresOn { get; init; }
        public required string CardCvv { get; init; }

        public CartPaymentViewModel()
        {
        }

        [SetsRequiredMembers]
        public CartPaymentViewModel(string cardHolder, string cardNumber, string cardExpiresOn, string cardCvv)
        {
            CardHolder = cardHolder;
            CardNumber = cardNumber;
            CardExpiresOn = cardExpiresOn;
            CardCvv = cardCvv;
        }
    }
}
