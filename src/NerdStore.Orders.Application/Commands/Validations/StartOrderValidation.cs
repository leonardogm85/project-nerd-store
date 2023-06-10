using FluentValidation;

namespace NerdStore.Orders.Application.Commands.Validations
{
    public class StartOrderValidation : AbstractValidator<StartOrderCommand>
    {
        public StartOrderValidation()
        {
            RuleFor(order => order.ClientId)
                .NotEmpty()
                .WithMessage("The client ID must be provided.");

            RuleFor(order => order.CardHolder)
                .NotEmpty()
                .WithMessage("The card holder must be provided.")
                .MinimumLength(10)
                .WithMessage("The card holder name must be a minimum of 10 characters.")
                .MaximumLength(100)
                .WithMessage("The card holder name must be a maximum of 100 characters.");

            RuleFor(order => order.CardNumber)
                .NotEmpty()
                .WithMessage("The card number must be provided.")
                .Length(16)
                .WithMessage("The card number must be 16 characters.");

            RuleFor(order => order.CardExpiresOn)
                .NotEmpty()
                .WithMessage("The card expires on must be provided.")
                .Length(5)
                .WithMessage("The card expires on must be 5 characters.");

            RuleFor(order => order.CardCvv)
                .NotEmpty()
                .WithMessage("The card CVV on must be provided.")
                .Length(3)
                .WithMessage("The card CVV must be 3 characters.");
        }
    }
}
