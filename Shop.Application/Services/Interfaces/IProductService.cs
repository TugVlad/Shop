using Shop.Core.Models;

namespace Shop.Application.Services.Interfaces
{
	public interface IProductService
	{
		Task<List<Product>> GetProductsAsync();
		Task<List<Product>> GetProductsCompleteInformationAsync();
		Task<Product> GetProductByIdAsync(int productId);
		Task<Product> AddProductAsync(Product product);
		Task<Product> AddProductReviewAsync(Review review);
		Task<Product> UpdateProductAsync(int productId, Product product);
		Task<bool> DeleteProductAsync(int productId);
		Task<bool> CheckIfProductsExistAsync(List<int> productIds);
		Task<bool> AddProductInCart(ProductInCart productInCart);
	}
}
