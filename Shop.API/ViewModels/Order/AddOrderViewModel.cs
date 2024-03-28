using Shop.Core.Enums;

namespace Shop.API.ViewModels.Order
{
	public class AddOrderViewModel
	{
		public string? Address { get; set; }
		public PaymentMethodEnum PaymentMethod { get; set; }
	}
}
