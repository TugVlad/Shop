using Shop.Application.Repositories.Interfaces;
using Shop.Models;
using Shop.Services.Interfaces;

namespace Shop.Services.Implementation
{
	public class ProductService : IProductService
	{
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

		public async Task<Product> AddProductAsync(Product product)
		{
			return await productRepository.AddProductAsync(product);
		}

		public async Task<bool> DeleteProductAsync(int productId)
		{
			return await productRepository.DeleteProductAsync(productId);
		}

		public async Task<Product> GetProductByIdAsync(int productId)
		{
			return await productRepository.GetProductByIdAsync(productId);
		}

		public async Task<List<Product>> GetProductsAsync()
		{
			return await productRepository.GetProductsAsync();
		}

		public async Task<Product> UpdateProductAsync(int productId, Product product)
		{
			return await productRepository.UpdateProductAsync(productId, product);
		}
	}
}
