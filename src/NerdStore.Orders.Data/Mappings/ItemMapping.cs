using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Orders.Data.Context;
using NerdStore.Orders.Domain.Entities;

namespace NerdStore.Orders.Data.Mappings
{
    public class ItemMapping : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(item => item.Id);

            builder.Property(item => item.ProductId)
                .IsRequired();

            builder.Property(item => item.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(item => item.Quantity)
                .IsRequired();

            builder.Property(item => item.Price)
                .IsRequired();

            builder.HasOne(item => item.Order)
                .WithMany(order => order.Items)
                .HasForeignKey(item => item.OrderId)
                .IsRequired();

            builder.ToTable(nameof(OrderContext.Items));
        }
    }
}
