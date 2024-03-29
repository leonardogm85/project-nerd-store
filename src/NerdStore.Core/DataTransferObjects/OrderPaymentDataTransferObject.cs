﻿namespace NerdStore.Core.DataTransferObjects
{
    public class OrderPaymentDataTransferObject : IDataTransferObject
    {
        public Guid OrderId { get; }
        public Guid ClientId { get; }
        public double Amount { get; }
        public string CardHolder { get; }
        public string CardNumber { get; }
        public string CardExpiresOn { get; }
        public string CardCvv { get; }

        public OrderPaymentDataTransferObject(Guid orderId, Guid clientId, double amount, string cardHolder, string cardNumber, string cardExpiresOn, string cardCvv)
        {
            OrderId = orderId;
            ClientId = clientId;
            Amount = amount;
            CardHolder = cardHolder;
            CardNumber = cardNumber;
            CardExpiresOn = cardExpiresOn;
            CardCvv = cardCvv;
        }
    }
}
