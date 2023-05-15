using Shop.Application.Repositories.Interfaces;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;
using Shop.Core.ViewModels;

namespace Shop.Application.Services.Implementations
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository productRepository;
		private readonly ICompanyRepository companyRepository;

		public ProductService(IProductRepository productRepository, ICompanyRepository companyRepository)
		{
			this.productRepository = productRepository;
			this.companyRepository = companyRepository;
		}

		public async Task<Product> AddProductAsync(ProductViewModel product)
		{
			return await productRepository.AddProductAsync(new Product(product));
		}

		public async Task<Product> AddProductReviewAsync(int productId, string reviewMessage)
		{
			var product = await productRepository.GetProductWithDependenciesByIdAsync(productId);

			if (product == null)
			{
				return null;
			}

			var review = new Review("title", reviewMessage, 5, product);

			return await productRepository.AddProductReviewAsync(product, review);
		}

		public async Task<Product> AddProductCompanyAsync(int productId, int companyId)
		{
			var product = await productRepository.GetProductWithDependenciesByIdAsync(productId);

			if (product == null)
			{
				return null;
			}

			var company = await companyRepository.GetCompanyByIdAsync(companyId);

			if (company == null || product.Companies.FirstOrDefault(e => e.Id == company.Id) != null)
			{
				return product;
			}

			return await productRepository.AddProductCompanyAsync(product, company);
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

		public async Task<List<Product>> GetProductsWithReviewsAsync()
		{
			return await productRepository.GetProductsWithReviewsAsync();
		}

		public async Task<Product> UpdateProductAsync(int productId, Product product)
		{
			return await productRepository.UpdateProductAsync(productId, product);
		}
	}
}
