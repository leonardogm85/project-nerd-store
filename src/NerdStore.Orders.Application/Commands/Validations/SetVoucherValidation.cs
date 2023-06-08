using FluentValidation;

namespace NerdStore.Orders.Application.Commands.Validations
{
    public class SetVoucherValidation : AbstractValidator<SetVoucherCommand>
    {
        public SetVoucherValidation()
        {
            RuleFor(voucher => voucher.ClientId)
                .NotEmpty()
                .WithMessage("The client ID must be provided.");

            RuleFor(voucher => voucher.VoucherCode)
                .NotEmpty()
                .WithMessage("The voucher code must be provided.")
                .MaximumLength(100)
                .WithMessage("The voucher code must be a maximum of 100 characters.");
        }
    }
}
