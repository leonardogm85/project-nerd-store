using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Payments.Domain.Entities;
using NerdStore.Payments.Data.Context;

namespace NerdStore.Payments.Data.Mappings
{
    public class PaymentMapping : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(payment => payment.Id);

            builder.Property(payment => payment.OrderId)
                .IsRequired();

            builder.Property(payment => payment.ClientId)
                .IsRequired();

            builder.Property(payment => payment.Amount)
                .IsRequired();

            builder.Property(payment => payment.CardHolder)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(payment => payment.CardNumber)
                .HasMaxLength(16)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(payment => payment.CardExpiresOn)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(payment => payment.CardCvv)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsRequired();

            builder.HasMany(payment => payment.Transactions)
                .WithOne(transaction => transaction.Payment)
                .HasForeignKey(transaction => transaction.PaymentId)
                .IsRequired(false);

            builder.ToTable(nameof(PaymentContext.Payments));
        }
    }
}
