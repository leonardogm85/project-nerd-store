using FluentValidation.Results;
using NerdStore.Core.Messages;
using NerdStore.Orders.Application.Commands.Validations;

namespace NerdStore.Orders.Application.Commands
{
    public class RemoveItemCommand : Command
    {
        public Guid ClientId { get; }
        public Guid ProductId { get; }

        public RemoveItemCommand(Guid clientId, Guid productId)
            : base(clientId)
        {
            ClientId = clientId;
            ProductId = productId;
        }

        public override ValidationResult GetValidationResult()
        {
            return new RemoveItemValidation().Validate(this);
        }
    }
}
