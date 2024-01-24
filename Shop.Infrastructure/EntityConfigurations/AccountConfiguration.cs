using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Models;

namespace Shop.Infrastructure.EntityConfigurations
{
	public class AccountConfiguration : IEntityTypeConfiguration<Account>
	{
		public void Configure(EntityTypeBuilder<Account> builder)
		{
			builder.HasOne(e => e.Cart)
				.WithOne(e => e.Account)
				.HasForeignKey<Cart>(e => e.AccountId)
				.IsRequired();
		}
	}
}
