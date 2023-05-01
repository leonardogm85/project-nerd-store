using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Orders.Data.Context;
using NerdStore.Orders.Domain.Entities;

namespace NerdStore.Orders.Data.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.Id);

            builder.Property(order => order.ClientId)
                .IsRequired();

            builder.HasOne(order => order.Voucher)
                .WithMany(voucher => voucher.Orders)
                .HasForeignKey(order => order.VoucherId)
                .IsRequired(false);

            builder.Property(o => o.Code)
                .HasDefaultValueSql("NEXT VALUE FOR MySequence")
                .IsRequired();

            builder.Property(order => order.VoucherUsed)
                .IsRequired();

            builder.Property(order => order.Discount)
                .IsRequired();

            builder.Property(order => order.Total)
                .IsRequired();

            builder.Property(order => order.Status)
                .IsRequired();

            builder.Property(order => order.CreatedAt)
                .IsRequired();

            builder.HasMany(order => order.Items)
                .WithOne(item => item.Order)
                .HasForeignKey(item => item.OrderId)
                .IsRequired(true);

            builder.ToTable(nameof(OrderContext.Orders));
        }
    }
}
