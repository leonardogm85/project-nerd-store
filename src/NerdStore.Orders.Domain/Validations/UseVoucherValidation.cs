using FluentValidation;
using NerdStore.Orders.Domain.Entities;

namespace NerdStore.Orders.Domain.Validations
{
    public class UseVoucherValidation : AbstractValidator<Voucher>
    {
        public UseVoucherValidation()
        {
            RuleFor(v => v.ValidUntil)
                .GreaterThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("The voucher is expired.");

            RuleFor(v => v.Active)
                .Equal(true)
                .WithMessage("The voucher is inactive.");

            RuleFor(v => v.Used)
                .Equal(false)
                .WithMessage("The voucher has already been used.");

            RuleFor(v => v.Quantity)
                .GreaterThan(0)
                .WithMessage("The voucher is no longer available.");
        }
    }
}
