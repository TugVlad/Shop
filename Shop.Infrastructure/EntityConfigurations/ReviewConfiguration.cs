using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Models;

namespace Shop.Infrastructure.EntityConfigurations
{
	public class ReviewConfiguration : IEntityTypeConfiguration<Review>
	{
		public void Configure(EntityTypeBuilder<Review> builder)
		{
			builder.HasOne(e => e.Product)
				.WithMany(f => f.Reviews)
				.HasForeignKey(e => e.ProductId)
				.IsRequired(false)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(e => e.Company)
				.WithMany(f => f.Reviews)
				.HasForeignKey(f => f.CompanyId)
				.IsRequired(false)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
