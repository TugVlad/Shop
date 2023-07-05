using Microsoft.EntityFrameworkCore;
using Shop.Application.Repositories.Interfaces;
using Shop.Core.Models;
using Shop.Data;

namespace Shop.Infrastructure.Repositories.Implementations
{
	public class ProductRepository : BaseRepository, IProductRepository
	{
		public ProductRepository(ShopContext context) : base(context) { }

		public async Task<Product> AddProductAsync(Product product)
		{
			await _context.Products.AddAsync(product);
			await SaveChangesAsync();
			return product;
		}

		public void DeleteProductAsync(Product product)
		{
			_context.Products.Remove(product);
		}

		public async Task<Product> GetProductByIdAsync(int productId)
		{
			return await _context.Products.FirstOrDefaultAsync(e => e.Id == productId);
		}

		public async Task<Product> GetProductWithDependenciesByIdAsync(int productId)
		{
			return await _context.Products
				.Include(e => e.Reviews)
				.FirstOrDefaultAsync(e => e.Id == productId);
		}

		public async Task<List<Product>> GetProductsAsync()
		{
			return await _context.Products.ToListAsync();
		}

		public async Task<List<Product>> GetProductsCompleteInformationAsync()
		{
			return await _context.Products.Include(e => e.Reviews).Include(e => e.Company).ToListAsync();
		}

		public async Task<List<Product>> GetProductsByIdsAsync(List<int> productIds)
		{
			return await _context.Products.Where(e => productIds.Contains(e.Id)).ToListAsync();
		}

		public async Task<int> GetProductCountBasedOnIds(List<int> productIds)
		{
			return await _context.Products.Where(e => productIds.Contains(e.Id)).CountAsync();
		}
	}
}
