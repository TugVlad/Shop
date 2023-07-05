using Shop.Core.Enums;

namespace Shop.API.ViewModels.Order
{
	public class OrderViewModel
	{
		public int Id { get; set; }
		public Guid UserId { get; set; }
		public string? Address { get; set; }
		public OrderStatusEnum OrderStatus { get; set; }
		public PaymentMethodEnum PaymentMethod { get; set; }
		public bool IsPaid { get; set; }
		public DateTime? PaidAt { get; set; }
		public List<ProductOrderViewModel> ProductOrders { get; set; }
	}
}
