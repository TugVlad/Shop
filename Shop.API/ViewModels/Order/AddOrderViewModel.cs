using Shop.Core.Enums;

namespace Shop.API.ViewModels.Order
{
	public class AddOrderViewModel
	{
		public Guid UserId { get; set; }
		public string? Address { get; set; }
		public PaymentMethodEnum PaymentMethod { get; set; }
	}
}
