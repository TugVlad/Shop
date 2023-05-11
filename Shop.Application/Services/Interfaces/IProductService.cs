using Shop.Core.Models;

namespace Shop.Services.Interfaces
{
	public interface IProductService
	{
		Task<List<Product>> GetProductsAsync();
		Task<List<Product>> GetProductsWithReviewsAsync();
		Task<Product> GetProductByIdAsync(int productId);
		Task<Product> AddProductAsync(Product product);
		Task<Product> UpdateProductAsync(int productId, Product product);
		Task<bool> DeleteProductAsync(int productId);
	}
}
