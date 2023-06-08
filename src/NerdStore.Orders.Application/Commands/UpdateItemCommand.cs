using FluentValidation.Results;
using NerdStore.Core.Messages;
using NerdStore.Orders.Application.Commands.Validations;

namespace NerdStore.Orders.Application.Commands
{
    public class UpdateItemCommand : Command
    {
        public Guid ClientId { get; }
        public Guid ProductId { get; }
        public string ProductName { get; }
        public int Quantity { get; }
        public double Price { get; }

        public UpdateItemCommand(Guid clientId, Guid productId, string productName, int quantity, double price)
            : base(clientId)
        {
            ClientId = clientId;
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }

        public override ValidationResult GetValidationResult()
        {
            return new UpdateItemValidation().Validate(this);
        }
    }
}
