using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Models;

namespace Shop.Infrastructure.EntityConfigurations
{
	public class CartProductConfiguration : IEntityTypeConfiguration<CartProduct>
	{
		public void Configure(EntityTypeBuilder<CartProduct> builder)
		{
			builder.ToTable("CartProduct");
			builder.HasKey(e => new { e.CartId, e.ProductId });

			builder.HasOne(e => e.Cart)
				.WithMany(f => f.CartProducts)
				.HasForeignKey(e => e.CartId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(e => e.Product)
				.WithMany(f => f.CartProducts)
				.HasForeignKey(e => e.ProductId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
