using FluentValidation.Results;
using NerdStore.Core.Messages;
using NerdStore.Orders.Application.Commands.Validations;

namespace NerdStore.Orders.Application.Commands
{
    public class StartOrderCommand : Command
    {
        public Guid ClientId { get; }
        public string CardHolder { get; }
        public string CardNumber { get; }
        public string CardExpiresOn { get; }
        public string CardCvv { get; }

        public StartOrderCommand(Guid clientId, string cardHolder, string cardNumber, string cardExpiresOn, string cardCvv)
            : base(clientId)
        {
            ClientId = clientId;
            CardHolder = cardHolder;
            CardNumber = cardNumber;
            CardExpiresOn = cardExpiresOn;
            CardCvv = cardCvv;
        }

        public override ValidationResult GetValidationResult()
        {
            return new StartOrderValidation().Validate(this);
        }
    }
}
