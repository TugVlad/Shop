﻿using Shop.Application.Repositories.Interfaces;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;

namespace Shop.Application.Services.Implementations
{
	public class ProductService : BaseService, IProductService
	{
		private readonly IProductRepository _productRepository;
		private readonly IProductInCartRepository _productInCartRepository;

		public ProductService(IProductRepository productRepository, IProductInCartRepository productInCartRepository, IUnitOfWork unitOfWork)
			: base(unitOfWork)
		{
			_productRepository = productRepository;
			_productInCartRepository = productInCartRepository;
		}

		public async Task<Product> AddProductAsync(Product product)
		{
			return await _productRepository.AddProductAsync(product);
		}

		public async Task<Product> AddProductReviewAsync(Review review)
		{
			var product = await _productRepository.GetProductWithDependenciesByIdAsync(review.ProductId.Value);

			if (product == null)
			{
				return null;
			}

			await _unitOfWork.BeginTransaction();

			try
			{
				product.AddReview(review);
				await _unitOfWork.SaveChangesAsync();

				await _unitOfWork.CommitTransaction();
				return product;
			}
			catch (Exception)
			{
				await _unitOfWork.RollbackTransaction();
			}

			return null;
		}

		public async Task<bool> DeleteProductAsync(int productId)
		{
			var product = await _productRepository.GetProductByIdAsync(productId);

			if (product == null)
			{
				return false;
			}

			await _unitOfWork.BeginTransaction();

			try
			{
				_productRepository.DeleteProductAsync(product);
				await _unitOfWork.SaveChangesAsync();

				await _unitOfWork.CommitTransaction();
				return true;
			}
			catch (Exception)
			{
				await _unitOfWork.RollbackTransaction();
			}

			return false;
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

			await _unitOfWork.BeginTransaction();

			try
			{
				currentProduct.UpdateProduct(product);

				await _unitOfWork.SaveChangesAsync();

				await _unitOfWork.CommitTransaction();
				return currentProduct;
			}
			catch (Exception)
			{
				await _unitOfWork.RollbackTransaction();
			}

			return null;
		}

		public async Task<bool> CheckIfProductsExistAsync(List<int> productIds)
		{
			var count = await _productRepository.GetProductCountBasedOnIds(productIds);
			return count == productIds.Count;
		}

		public async Task<bool> AddProductInCart(ProductInCart productInCart)
		{
			var product = await _productRepository.GetProductByIdAsync(productInCart.ProductId);
			if (product == null || product.Quantity < productInCart.Quantity)
			{
				return false;
			}

			await _unitOfWork.BeginTransaction();

			try
			{
				await _productInCartRepository.AddProductInCartAsync(productInCart);
				await _unitOfWork.SaveChangesAsync();

				await _unitOfWork.CommitTransaction();
				return true;
			}
			catch (Exception)
			{
				await _unitOfWork.RollbackTransaction();
			}

			return false;
		}
	}
}
