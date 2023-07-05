using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Models;

namespace Shop.Infrastructure.EntityConfigurations
{
	public class ProductInCartConfiguration : IEntityTypeConfiguration<ProductInCart>
	{
		public void Configure(EntityTypeBuilder<ProductInCart> builder)
		{
			builder.HasKey(e => new { e.AccountId, e.ProductId });

			builder.HasOne(e => e.Account)
				.WithMany(f => f.ProductsInCart)
				.HasForeignKey(e => e.AccountId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(e => e.Product)
				.WithMany(f => f.ProductsInCart)
				.HasForeignKey(e => e.ProductId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
