using Shop.Core.Models;

namespace Shop.Application.Repositories.Interfaces
{
	public interface IProductInCartRepository
	{
		Task<ProductInCart> AddProductInCartAsync(ProductInCart productInCart);
		Task<List<ProductInCart>> GetProductsInCartForAccountIdAsync(Guid accountId);
		void DeleteProductsFromCart(List<ProductInCart> productsInCart);
	}
}
