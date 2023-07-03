using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Models;

namespace Shop.Infrastructure.EntityConfigurations
{
	public class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrder>
	{
		public void Configure(EntityTypeBuilder<ProductOrder> builder)
		{
			builder.HasKey(e => new { e.ProductId, e.OrderId });

			builder.HasOne(e => e.Product)
				.WithMany(f => f.ProductOrders)
				.HasForeignKey(e => e.ProductId);

			builder.HasOne(e => e.Order)
				.WithMany(f => f.ProductOrders)
				.HasForeignKey(e => e.OrderId);
		}
	}
}
