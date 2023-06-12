using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Payments.Domain.Entities;
using NerdStore.Payments.Data.Context;

namespace NerdStore.Payments.Data.Mappings
{
    public class TransactionMapping : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(transaction => transaction.Id);

            builder.HasOne(transaction => transaction.Payment)
                .WithMany(payment => payment.Transactions)
                .HasForeignKey(transaction => transaction.PaymentId)
                .IsRequired();

            builder.Property(transaction => transaction.Amount)
                .IsRequired();

            builder.Property(transaction => transaction.Status)
                .IsRequired();

            builder.ToTable(nameof(PaymentContext.Transactions));
        }
    }
}
