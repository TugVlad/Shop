using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Models;

namespace Shop.Infrastructure.EntityConfigurations
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.Property(e => e.OrderStatus).HasColumnType("nvarchar(50)").IsRequired();
			builder.Property(e => e.PaymentMethod).HasColumnType("nvarchar(50)").IsRequired();

			builder.HasOne(e => e.User)
				.WithMany(f => f.Orders)
				.HasForeignKey(e => e.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(e => e.Product)
				.WithMany(f => f.Orders)
				.HasForeignKey(e => e.ProductId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
