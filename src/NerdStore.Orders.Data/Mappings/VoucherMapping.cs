using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Orders.Data.Context;
using NerdStore.Orders.Domain.Entities;

namespace NerdStore.Orders.Data.Mappings
{
    public class VoucherMapping : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.HasKey(voucher => voucher.Id);

            builder.Property(item => item.Code)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(voucher => voucher.Value)
                .IsRequired();

            builder.Property(voucher => voucher.Quantity)
                .IsRequired();

            builder.Property(voucher => voucher.DiscountType)
                .IsRequired();

            builder.Property(voucher => voucher.CreatedAt)
                .IsRequired();

            builder.Property(voucher => voucher.ValidUntil)
                .IsRequired();

            builder.Property(voucher => voucher.UsedAt)
                .IsRequired(false);

            builder.Property(voucher => voucher.Active)
                .IsRequired();

            builder.Property(voucher => voucher.Used)
                .IsRequired();

            builder.HasMany(voucher => voucher.Orders)
                .WithOne(order => order.Voucher)
                .HasForeignKey(order => order.VoucherId)
                .IsRequired(false);

            builder.ToTable(nameof(OrderContext.Vouchers));
        }
    }
}
