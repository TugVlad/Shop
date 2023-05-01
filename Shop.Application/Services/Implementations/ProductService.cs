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

		public async Task<Product> AddProduct(Product product)
		{
			return await productRepository.AddProduct(product);
		}

		public async Task<bool> DeleteProduct(int productId)
		{
			return await productRepository.DeleteProduct(productId);
		}

		public async Task<Product> GetProductById(int productId)
		{
			return await productRepository.GetProductById(productId);
		}

		public async Task<List<Product>> GetProducts()
		{
			return await productRepository.GetProducts();
		}

		public async Task<Product> UpdateProduct(int productId, Product product)
		{
			return await productRepository.UpdateProduct(productId, product);
		}
	}
}
