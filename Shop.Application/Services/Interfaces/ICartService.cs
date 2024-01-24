using Shop.Core.Models;

namespace Shop.Application.Services.Interfaces
{
	public interface ICartService
	{
		Task<Cart> AddProductToCart(Guid accountId, CartProduct cartProduct);
	}
}
