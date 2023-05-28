using Microsoft.EntityFrameworkCore;
using Shop.Core.Models;
using Shop.Infrastructure.EntityConfigurations;

namespace Shop.Data
{
	public class ShopContext : DbContext
	{
		public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

		public DbSet<Product> Products { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<Company> Companies { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProductConfiguration());
		}
	}
}
