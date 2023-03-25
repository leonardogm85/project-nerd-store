using FluentValidation;
using NerdStore.Core.Messages;

namespace NerdStore.Orders.Application.Commands
{
    public class SetVoucherCommand : Command
    {
        public Guid ClientId { get; private set; }
        public string VoucherCode { get; private set; }

        public SetVoucherCommand(Guid clientId, string voucherCode) : base(clientId)
        {
            ClientId = clientId;
            VoucherCode = voucherCode;
        }

        public override bool IsValid()
        {
            ValidationResult = new SetVoucherValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class SetVoucherValidation : AbstractValidator<SetVoucherCommand>
    {
        public SetVoucherValidation()
        {
            RuleFor(voucher => voucher.ClientId)
                .NotEmpty()
                .WithMessage("The client ID must be provided.");

            RuleFor(voucher => voucher.VoucherCode)
                .NotEmpty()
                .WithMessage("The voucher code must be provided.");
        }
    }
}
