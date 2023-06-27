using Microsoft.EntityFrameworkCore;
using Shop.Application.Repositories.Interfaces;
using Shop.Core.Models;
using Shop.Data;

namespace Shop.Infrastructure.Repositories.Implementations
{
	public class ProductRepository : IProductRepository
	{
		private readonly ShopContext _context;

		public ProductRepository(ShopContext shopContext)
		{
			_context = shopContext;
		}

		public async Task<Product> AddProductAsync(Product product)
		{
			await _context.Products.AddAsync(product);
			await SaveChangesAsync();
			return product;
		}
		public async Task<Product> AddProductReviewAsync(Product product, Review review)
		{
			product.AddReview(review);
			await SaveChangesAsync();

			return product;
		}

		//TODO replace company with companyID
		public async Task<Product> AddProductCompanyAsync(Product product, int companyId)
		{
			product.AddCompany(companyId);
			await SaveChangesAsync();

			return product;
		}

		public async Task<bool> DeleteProductAsync(int productId)
		{
			var product = await _context.Products.FirstOrDefaultAsync(e => e.Id == productId);

			if (product == null)
			{
				return false;
			}

			_context.Products.Remove(product);
			await SaveChangesAsync();

			return true;

		}

		public async Task<Product> GetProductByIdAsync(int productId)
		{
			return await _context.Products.FirstOrDefaultAsync(e => e.Id == productId);
		}

		public async Task<Product> GetProductWithDependenciesByIdAsync(int productId)
		{
			return await _context.Products
				.Include(e => e.Reviews)
				.Include(e => e.CompanyProducts)
				.FirstOrDefaultAsync(e => e.Id == productId);
		}

		public async Task<List<Product>> GetProductsAsync()
		{
			return await _context.Products.ToListAsync();
		}

		public async Task<List<Product>> GetProductsCompleteInformationAsync()
		{
			return await _context.Products.Include(e => e.Reviews).Include(e => e.CompanyProducts).ToListAsync();
		}

		public async Task<Product> UpdateProductAsync(int productId, Product product)
		{
			var existingProduct = await _context.Products.FirstOrDefaultAsync(e => e.Id == productId);

			if (existingProduct == null)
			{
				return null;
			}

			_context.Update(existingProduct);
			existingProduct.UpdateName(product.Name);
			existingProduct.UpdateDescription(product.Description);
			existingProduct.UpdateType(product.Type);
			existingProduct.UpdatePrice(product.Price);
			existingProduct.UpdateQuantity(product.Quantity);
			await SaveChangesAsync();

			return existingProduct;
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}

	}
}
