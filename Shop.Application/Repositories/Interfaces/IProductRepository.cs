using Shop.Models;

namespace Shop.Application.Repositories.Interfaces
{
	public interface IProductRepository
	{
		Task<List<Product>> GetProductsAsync();
		Task<Product> GetProductByIdAsync(int productId);
		Task<Product> AddProductAsync(Product product);
		Task<Product> UpdateProductAsync(int productId, Product product);
		Task<bool> DeleteProductAsync(int productId);
	}
}
