namespace NerdStore.Orders.Application.Queries.ViewModels
{
    public class CartPaymentViewModel
    {
        public string CardHolder { get; }
        public string CardNumber { get; }
        public string CardExpiresOn { get; }
        public string CardCvv { get; }

        public CartPaymentViewModel(string cardHolder, string cardNumber, string cardExpiresOn, string cardCvv)
        {
            CardHolder = cardHolder;
            CardNumber = cardNumber;
            CardExpiresOn = cardExpiresOn;
            CardCvv = cardCvv;
        }
    }
}
