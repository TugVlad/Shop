using Shop.API.ViewModels.Cart.CartProducts;
using Shop.Core.Models;

namespace Shop.API.ViewModels.Cart
{
	public class SimpleCartViewModel
	{
		public int Id { get; set; }
		public decimal TotalPrice { get; set; }
		public List<SimpleCartProductViewModel> CartProducts { get; set; }
	}
}
