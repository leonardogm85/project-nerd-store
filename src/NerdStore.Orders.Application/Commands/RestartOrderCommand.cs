using FluentValidation.Results;
using NerdStore.Core.Messages;
using NerdStore.Orders.Application.Commands.Validations;

namespace NerdStore.Orders.Application.Commands
{
    public class RestartOrderCommand : Command
    {
        public Guid OrderId { get; }
        public Guid ClientId { get; }

        public RestartOrderCommand(Guid orderId, Guid clientId)
            : base(orderId)
        {
            OrderId = orderId;
            ClientId = clientId;
        }

        public override ValidationResult GetValidationResult()
        {
            return new RestartOrderValidation().Validate(this);
        }
    }
}
