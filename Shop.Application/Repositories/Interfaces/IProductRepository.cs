using Shop.Core.Models;

namespace Shop.Application.Repositories.Interfaces
{
	public interface IProductRepository : IBaseRepository
	{
		Task<List<Product>> GetProductsAsync();
		Task<List<Product>> GetProductsCompleteInformationAsync();
		Task<Product> GetProductByIdAsync(int productId);
		Task<Product> GetProductWithDependenciesByIdAsync(int productId);
		Task<Product> AddProductAsync(Product product);
		void DeleteProductAsync(Product product);
		Task<int> GetProductCountBasedOnIds(List<int> productIds);
		Task<List<Product>> GetProductsByIdsAsync(List<int> productIds);
	}
}
