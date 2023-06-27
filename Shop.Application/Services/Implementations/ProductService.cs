using Shop.Application.Repositories.Interfaces;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;

namespace Shop.Application.Services.Implementations
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;
		private readonly ICompanyRepository _companyRepository;

		public ProductService(IProductRepository productRepository, ICompanyRepository companyRepository)
		{
			_productRepository = productRepository;
			_companyRepository = companyRepository;
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

			return await _productRepository.AddProductReviewAsync(product, review);
		}

		public async Task<Product> AddProductCompanyAsync(int productId, int companyId)
		{
			var product = await _productRepository.GetProductWithDependenciesByIdAsync(productId);

			if (product == null)
			{
				return null;
			}

			var company = await _companyRepository.GetCompanyByIdAsync(companyId);

			//TODO return proper message if company doesn't exist
			if (company == null || product.CompanyProducts.FirstOrDefault(e => e.CompanyId == company.Id) != null)
			{
				return product;
			}

			return await _productRepository.AddProductCompanyAsync(product, companyId);
		}

		public async Task<bool> DeleteProductAsync(int productId)
		{
			return await _productRepository.DeleteProductAsync(productId);
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
			return await _productRepository.UpdateProductAsync(productId, product);
		}
	}
}
