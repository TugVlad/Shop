using Microsoft.EntityFrameworkCore;
using Shop.Application.Repositories.Interfaces;
using Shop.Core.Models;
using Shop.Data;

namespace Shop.Infrastructure.Repositories.Implementations
{
	public class ProductInCartRepository : BaseRepository, IProductInCartRepository
	{
		public ProductInCartRepository(ShopContext context) : base(context) { }

		public async Task<ProductInCart> AddProductInCartAsync(ProductInCart productInCart)
		{
			await _context.ProductsInCart.AddAsync(productInCart);
			return productInCart;
		}

		public void DeleteProductsFromCart(List<ProductInCart> productsInCart)
		{
			_context.ProductsInCart.RemoveRange(productsInCart);
		}

		public async Task<List<ProductInCart>> GetProductsInCartForAccountIdAsync(Guid accountId)
		{
			return await _context.ProductsInCart.Where(e => e.AccountId == accountId).ToListAsync();
		}
	}
}
