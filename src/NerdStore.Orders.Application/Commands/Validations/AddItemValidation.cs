using FluentValidation;

namespace NerdStore.Orders.Application.Commands.Validations
{
    public class AddItemValidation : AbstractValidator<AddItemCommand>
    {
        public AddItemValidation()
        {
            RuleFor(item => item.ClientId)
                .NotEmpty()
                .WithMessage("The client ID must be provided.");

            RuleFor(item => item.ProductId)
                .NotEmpty()
                .WithMessage("The product ID must be provided.");

            RuleFor(item => item.ProductName)
                .NotEmpty()
                .WithMessage("The product name must be provided.")
                .MaximumLength(100)
                .WithMessage("The product name must be a maximum of 100 characters.");

            RuleFor(item => item.Quantity)
                .GreaterThan(0)
                .WithMessage("The quantity must be greater than 0.")
                .LessThanOrEqualTo(15)
                .WithMessage("The quantity must be less than or equal to 15.");

            RuleFor(item => item.Price)
                .GreaterThan(0)
                .WithMessage("The price must be greater than 0.");
        }
    }
}
