namespace NerdStore.Orders.Application.Queries.ViewModels
{
    public class CartPaymentViewModel
    {
        public string CardHolder { get; private set; }
        public string CardNumber { get; private set; }
        public string CardExpiresOn { get; private set; }
        public string CardCvv { get; private set; }

        public CartPaymentViewModel(string cardHolder, string cardNumber, string cardExpiresOn, string cardCvv)
        {
            CardHolder = cardHolder;
            CardNumber = cardNumber;
            CardExpiresOn = cardExpiresOn;
            CardCvv = cardCvv;
        }
    }
}
