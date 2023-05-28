using Shop.Core.Models;

namespace Shop.Application.Repositories.Interfaces
{
	public interface IProductRepository
	{
		Task<List<Product>> GetProductsAsync();
		Task<List<Product>> GetProductsWithReviewsAsync();
		Task<Product> GetProductByIdAsync(int productId);
		Task<Product> GetProductWithDependenciesByIdAsync(int productId);
		Task<Product> AddProductAsync(Product product);
		Task<Product> AddProductReviewAsync(Product product, Review review);
		Task<Product> AddProductCompanyAsync(Product product, Company company);
		Task<Product> UpdateProductAsync(int productId, Product product);
		Task<bool> DeleteProductAsync(int productId);
	}
}
