using Microsoft.EntityFrameworkCore;
using Shop.Application.Repositories.Interfaces;
using Shop.Core.Models;
using Shop.Data;

namespace Shop.Infrastructure.Repositories.Implementations
{
	public class CartRepository : BaseRepository, ICartRepository
	{
		public CartRepository(ShopContext context) : base(context) { }

		public async Task<CartProduct> AddProductInCartAsync(CartProduct cartProduct)
		{
			await _context.CartProducts.AddAsync(cartProduct);
			return cartProduct;
		}

		public void DeleteProductsFromCart(List<CartProduct> cartProducts)
		{
			_context.CartProducts.RemoveRange(cartProducts);
		}

		public Task<Cart> GetCartByAccountIdAsync(Guid accountId)
		{
			return _context.Cart.FirstOrDefaultAsync(e => e.AccountId == accountId);
		}

		public Task<CartProduct> GetCartProductAsync(int cartId, int productId)
		{
			return _context.CartProducts
				.Include(e=>e.Product)
				.FirstOrDefaultAsync(e=>e.CartId == cartId && e.ProductId == productId);
		}

		public async Task<List<CartProduct>> GetCartProductsByAccountIdAsync(Guid accountId)
		{
			return await _context.CartProducts.ToListAsync();
		}
	}
}
