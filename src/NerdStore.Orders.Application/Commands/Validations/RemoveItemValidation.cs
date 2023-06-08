using FluentValidation;

namespace NerdStore.Orders.Application.Commands.Validations
{
    public class RemoveItemValidation : AbstractValidator<RemoveItemCommand>
    {
        public RemoveItemValidation()
        {
            RuleFor(item => item.ClientId)
                .NotEmpty()
                .WithMessage("The client ID must be provided.");

            RuleFor(item => item.ProductId)
                .NotEmpty()
                .WithMessage("The product ID must be provided.");
        }
    }
}
