using FluentValidation;
using NerdStore.Core.Messages;

namespace NerdStore.Orders.Application.Commands
{
    public class RemoveItemCommand : Command
    {
        public Guid ClientId { get; private set; }
        public Guid ProductId { get; private set; }

        public RemoveItemCommand(Guid clientId, Guid productId) : base(clientId)
        {
            ClientId = clientId;
            ProductId = productId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveItemValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

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
