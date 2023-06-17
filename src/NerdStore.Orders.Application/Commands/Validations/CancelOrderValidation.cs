using FluentValidation;

namespace NerdStore.Orders.Application.Commands.Validations
{
    public class CancelOrderValidation : AbstractValidator<CancelOrderCommand>
    {
        public CancelOrderValidation()
        {
            RuleFor(item => item.OrderId)
                .NotEmpty()
                .WithMessage("The order ID must be provided.");

            RuleFor(item => item.ClientId)
                .NotEmpty()
                .WithMessage("The client ID must be provided.");
        }
    }
}
