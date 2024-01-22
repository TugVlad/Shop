using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shop.Infrastructure.EntityConfigurations
{
	public class IdentityUserTokenConfiguration : IEntityTypeConfiguration<IdentityUserToken<string>>
	{
		public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
		{
			builder.HasNoKey();
		}
	}
}
