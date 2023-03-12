using FluentValidation;
using NerdStore.Core.Messages;

namespace NerdStore.Orders.Application.Commands
{
    public class AddItemCommand : Command
    {
        public Guid ClientId { get; private set; }
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public double Price { get; private set; }

        public AddItemCommand(Guid clientId, Guid productId, string productName, int quantity, double price) : base(clientId)
        {
            ClientId = clientId;
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddItemValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

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
                .WithMessage("The product name must be provided.");

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
