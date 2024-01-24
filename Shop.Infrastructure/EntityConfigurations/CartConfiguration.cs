using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Models;

namespace Shop.Infrastructure.EntityConfigurations
{
	public class CartConfiguration : IEntityTypeConfiguration<Cart>
	{
		public void Configure(EntityTypeBuilder<Cart> builder)
		{
			builder.HasOne(e => e.Account)
				.WithOne(e => e.Cart)
				.HasForeignKey<Cart>(e => e.AccountId)
				.IsRequired();
		}
	}
}
