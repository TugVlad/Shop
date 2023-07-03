using Shop.Application.Repositories.Interfaces;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;

namespace Shop.Application.Services.Implementations
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task<Product> AddProductAsync(Product product)
		{
			return await _productRepository.AddProductAsync(product);
		}

		public async Task<Product> AddProductReviewAsync(int productId, string reviewMessage)
		{
			var product = await _productRepository.GetProductWithDependenciesByIdAsync(productId);

			if (product == null)
			{
				return null;
			}

			var review = new Review("title", reviewMessage, 5, product);
			product.AddReview(review);
			await _productRepository.SaveChangesAsync();

			return product;
		}

		public async Task<bool> DeleteProductAsync(int productId)
		{
			var product = await _productRepository.GetProductByIdAsync(productId);

			if (product == null)
			{
				return false;
			}

			return await _productRepository.DeleteProductAsync(product);
		}

		public async Task<Product> GetProductByIdAsync(int productId)
		{
			return await _productRepository.GetProductByIdAsync(productId);
		}

		public async Task<List<Product>> GetProductsAsync()
		{
			return await _productRepository.GetProductsAsync();
		}

		public async Task<List<Product>> GetProductsCompleteInformationAsync()
		{
			return await _productRepository.GetProductsCompleteInformationAsync();
		}

		public async Task<Product> UpdateProductAsync(int productId, Product product)
		{
			var currentProduct = await _productRepository.GetProductByIdAsync(productId);

			if (currentProduct == null)
			{
				return null;
			}

			currentProduct.UpdateName(product.Name);
			currentProduct.UpdateDescription(product.Description);
			currentProduct.UpdateType(product.Type);
			currentProduct.UpdatePrice(product.Price);
			currentProduct.UpdateQuantity(product.Quantity);

			await _productRepository.SaveChangesAsync();

			return currentProduct;
		}

		public async Task<bool> CheckIfProductsExistAsync(List<int> productIds)
		{
			var count = await _productRepository.GetProductCountBasedOnIds(productIds);
			return count == productIds.Count;
		}
	}
}
