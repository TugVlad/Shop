using Shop.Core.Models;
using Shop.Core.ViewModels;

namespace Shop.Application.Services.Interfaces
{
	public interface IProductService
	{
		Task<List<Product>> GetProductsAsync();
		Task<List<Product>> GetProductsWithReviewsAsync();
		Task<Product> GetProductByIdAsync(int productId);
		Task<Product> AddProductAsync(ProductViewModel product);
		Task<Product> AddProductReviewAsync(int productId, string reviewMessage);
		Task<Product> AddProductCompanyAsync(int productId, int companyId);
		Task<Product> UpdateProductAsync(int productId, Product product);
		Task<bool> DeleteProductAsync(int productId);
	}
}
