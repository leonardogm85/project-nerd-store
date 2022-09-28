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
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(product => product.Description)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(product => product.Active)
                .IsRequired();

            builder.Property(product => product.Price)
                .IsRequired();

            builder.Property(product => product.Image)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

            builder.Property(product => product.QuantityInStock)
                .IsRequired();

            builder.Property(product => product.CreatedAt)
                .IsRequired();

            builder.OwnsOne(product => product.Dimension, builder =>
            {
                builder.Property(dimension => dimension.Width)
                    .IsRequired()
                    .HasColumnName(nameof(Dimension.Width));

                builder.Property(dimension => dimension.Height)
                    .IsRequired()
                    .HasColumnName(nameof(Dimension.Height));

                builder.Property(dimension => dimension.Depth)
                    .IsRequired()
                    .HasColumnName(nameof(Dimension.Depth));
            });

            builder.HasOne(product => product.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(product => product.CategoryId)
                .IsRequired();

            builder.ToTable(nameof(CatalogContext.Products));
        }
    }
}
