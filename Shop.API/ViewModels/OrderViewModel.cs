using Shop.Core.Enums;

namespace Shop.API.ViewModels
{
	public class OrderViewModel
	{
		public Guid UserId { get; set; }
		public string? Address { get; set; }
		public PaymentMethodEnum PaymentMethod { get; set; }
	}
}
