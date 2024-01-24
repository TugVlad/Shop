using Shop.Core.Models;

namespace Shop.Application.Repositories.Interfaces
{
	public interface ICartRepository
	{
		Task<CartProduct> AddProductInCartAsync(CartProduct productInCart);
		Task<List<CartProduct>> GetCartProductsByAccountIdAsync(Guid accountId);
		void DeleteProductsFromCart(List<CartProduct> productsInCart);
		Task<CartProduct> GetCartProductAsync(int cartId, int productId);
		Task<Cart> GetCartByAccountIdAsync(Guid accountId);
	}
}
