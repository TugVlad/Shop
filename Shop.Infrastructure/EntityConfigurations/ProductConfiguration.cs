using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Models;

namespace Shop.Infrastructure.EntityConfigurations
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.Property(e => e.Name).HasColumnType("varchar(250)").IsRequired();
			builder.Property(e => e.Description).HasColumnType("varchar(500)");
			builder.Property(e => e.Type).HasColumnType("nvarchar(50)").IsRequired();
			builder.Property(e => e.Price).HasColumnType("decimal(5, 2)");

			builder.HasOne(e => e.Company)
				.WithMany(f => f.Products)
				.HasForeignKey(f => f.CompanyId)
				.IsRequired(false)
				.OnDelete(DeleteBehavior.SetNull);
		}
	}
}
