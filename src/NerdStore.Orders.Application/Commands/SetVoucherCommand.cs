using FluentValidation.Results;
using NerdStore.Core.Messages;
using NerdStore.Orders.Application.Commands.Validations;

namespace NerdStore.Orders.Application.Commands
{
    public class SetVoucherCommand : Command
    {
        public Guid ClientId { get; }
        public string VoucherCode { get; }

        public SetVoucherCommand(Guid clientId, string voucherCode)
            : base(clientId)
        {
            ClientId = clientId;
            VoucherCode = voucherCode;
        }

        public override ValidationResult GetValidationResult()
        {
            return new SetVoucherValidation().Validate(this);
        }
    }
}
