using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Models;

namespace Shop.Infrastructure.EntityConfigurations
{
	public class CompanyProductConfiguration : IEntityTypeConfiguration<CompanyProduct>
	{
		public void Configure(EntityTypeBuilder<CompanyProduct> builder)
		{
			builder.HasKey(e => new { e.ProductId, e.CompanyId });

			builder.HasOne(e => e.Company)
				.WithMany(f => f.CompanyProducts)
				.HasForeignKey(e => e.CompanyId);

			builder.HasOne(e => e.Product)
				.WithMany(f => f.CompanyProducts)
				.HasForeignKey(e => e.ProductId);
		}
	}
}
