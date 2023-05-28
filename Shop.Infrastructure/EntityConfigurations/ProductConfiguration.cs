using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		}
	}
}
