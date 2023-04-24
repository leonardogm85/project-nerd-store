using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalog.Data.Context;
using NerdStore.Catalog.Domain.Entities;

namespace NerdStore.Catalog.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);

            builder.Property(product => product.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(product => product.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(product => product.Active)
                .IsRequired();

            builder.Property(product => product.Price)
                .IsRequired();

            builder.Property(product => product.Image)
                .HasMaxLength(250)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(product => product.QuantityInStock)
                .IsRequired();

            builder.Property(product => product.CreatedAt)
                .IsRequired();

            builder.OwnsOne(product => product.Dimension, builder =>
            {
                builder.Property(dimension => dimension.Width)
                    .HasColumnName(nameof(Dimension.Width))
                    .IsRequired();

                builder.Property(dimension => dimension.Height)
                    .HasColumnName(nameof(Dimension.Height))
                    .IsRequired();

                builder.Property(dimension => dimension.Depth)
                    .HasColumnName(nameof(Dimension.Depth))
                    .IsRequired();
            });

            builder.HasOne(product => product.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(product => product.CategoryId)
                .IsRequired();

            builder.ToTable(nameof(CatalogContext.Products));
        }
    }
}
