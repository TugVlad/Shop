using Shop.Models;

namespace Shop.Application.Repositories.Interfaces
{
	public interface IProductRepository
	{
		Task<List<Product>> GetProducts();
		Task<Product> GetProductById(int productId);
		Task<Product> AddProduct(Product product);
		Task<Product> UpdateProduct(int productId, Product product);
		Task<bool> DeleteProduct(int productId);
	}
}
