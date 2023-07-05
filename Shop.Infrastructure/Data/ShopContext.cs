using Microsoft.EntityFrameworkCore;
using Shop.Core.Models;
using System.Reflection;

namespace Shop.Data
{
	public class ShopContext : DbContext
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
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(),
				t => t.GetInterfaces().Any(i =>
				i.IsGenericType &&
				i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));
		}
	}
}
