using Microsoft.EntityFrameworkCore;
using Shop.Core.Models;

namespace Shop.Data
{
	public class ShopContext : DbContext
	{
		public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

		public DbSet<Product> Products { get; set; }
		public DbSet<Review> Reviews { get; set; }
	}
}
