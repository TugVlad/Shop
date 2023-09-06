using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Core.Models;

namespace Shop.Data
{
	public class ShopContext : IdentityDbContext
	{
		public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

		public DbSet<Product> Products { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<Account> Accounts { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<ProductOrder> ProductOrders { get; set; }
		public DbSet<ProductInCart> ProductsInCart { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopContext).Assembly);
		}
	}
}
