using Shop.Application.Repositories.Interfaces;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;

namespace Shop.Application.Services.Implementations
{
	public class CartService : BaseService, ICartService
	{
		private readonly ICartRepository _cartRepository;
		private readonly IProductRepository _productRepository;
		public CartService(ICartRepository cartRepository, IProductRepository productRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
		{
			_cartRepository = cartRepository;
			_productRepository = productRepository;
		}

		public async Task<Cart> AddProductToCart(Guid accountId, CartProduct cartProduct)
		{
			var cart = await _cartRepository.GetCartByAccountIdAsync(accountId);

			var existingCartProduct = await _cartRepository.GetCartProductAsync(cart.Id, cartProduct.ProductId);
			if (existingCartProduct != null)
			{
				cart.UpdateProduct(existingCartProduct, existingCartProduct.Quantity + cartProduct.Quantity);
			}
			else
			{
				cartProduct.UpdateProduct(await _productRepository.GetProductByIdAsync(cartProduct.ProductId));
				cart.AddProduct(cartProduct);
			}

			await _unitOfWork.SaveChangesAsync();

			return cart;
		}
	}
}
