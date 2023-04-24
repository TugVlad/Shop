using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using Shop.Services.Interfaces;

namespace Shop.Services.Implementation
{
	public class ProductService : IProductService
	{
		private readonly ShopContext context;

		public ProductService(ShopContext shopContext)
		{
			this.context = shopContext;
		}

		public async Task<Product> AddProduct(Product product)
		{
			await context.Products.AddAsync(product);
			await SaveChanges();
			return product;
		}

		public async Task<bool> DeleteProduct(int productId)
		{
			var product = await context.Products.FirstOrDefaultAsync(e => e.Id == productId);

			if (product == null)
			{
				return false;
			}

			context.Products.Remove(product);
			await SaveChanges();

			return true;

		}

		public async Task<Product> GetProductById(int productId)
		{
			return await context.Products.FirstOrDefaultAsync(e => e.Id == productId);
		}

		public async Task<List<Product>> GetProducts()
		{
			return await context.Products.ToListAsync();
		}

		public async Task<Product> UpdateProduct(int productId, Product product)
		{
			var existingProduct = await context.Products.FirstOrDefaultAsync(e => e.Id == productId);

			if (existingProduct == null)
			{
				return null;
			}

			context.Update(existingProduct);
			existingProduct.Name = product.Name;
			existingProduct.Price = product.Price;
			existingProduct.Description = product.Description;
			existingProduct.Type = product.Type;
			await SaveChanges();

			return existingProduct;
		}

		public async Task SaveChanges()
		{
			context.SaveChangesAsync();
		}
	}
}
