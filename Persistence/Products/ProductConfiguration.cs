using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Products
{
    /// <summary>
    /// Represents the EF configuration for the <see cref="Attendee"/> entity.
    /// </summary>
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        /// <inheritdoc />
		public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.OwnsOne(p => p.Price, priceBuilder =>
            {
                priceBuilder.WithOwner();
                priceBuilder.Property(m => m.Currency)
                .HasMaxLength(3);
            });
        }
    }
}
