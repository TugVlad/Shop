using Microsoft.EntityFrameworkCore;
using Shop.Application.Repositories.Interfaces;
using Shop.Core.Models;
using Shop.Data;

namespace Shop.Infrastructure.Repositories.Implementations
{
	public class ProductRepository : IProductRepository
	{
		private readonly ShopContext context;

		public ProductRepository(ShopContext shopContext)
		{
			this.context = shopContext;
		}

		public async Task<Product> AddProductAsync(Product product)
		{
			await context.Products.AddAsync(product);
			await SaveChangesAsync();
			return product;
		}

		public async Task<bool> DeleteProductAsync(int productId)
		{
			var product = await context.Products.FirstOrDefaultAsync(e => e.Id == productId);

			if (product == null)
			{
				return false;
			}

			context.Products.Remove(product);
			await SaveChangesAsync();

			return true;

		}

		public async Task<Product> GetProductByIdAsync(int productId)
		{
			return await context.Products.FirstOrDefaultAsync(e => e.Id == productId);
		}

		public async Task<List<Product>> GetProductsAsync()
		{
			return await context.Products.ToListAsync();
		}

		public async Task<List<Product>> GetProductsWithReviewsAsync()
		{
			return await context.Products.Include(e => e.Reviews).ToListAsync();
		}

		public async Task<Product> UpdateProductAsync(int productId, Product product)
		{
			var existingProduct = await context.Products.FirstOrDefaultAsync(e => e.Id == productId);

			if (existingProduct == null)
			{
				return null;
			}

			context.Update(existingProduct);
			existingProduct.UpdateProduct(product);
			await SaveChangesAsync();

			return existingProduct;
		}

		public async Task SaveChangesAsync()
		{
			context.SaveChangesAsync();
		}
	}
}
