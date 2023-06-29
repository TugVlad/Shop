using Shop.Core.Enums;

namespace Shop.Core.Models
{
	public class Order : BaseClass
	{
		public Order(Guid userId, int productId, int quantity, string address, OrderStatusEnum orderStatus, PaymentMethodEnum paymentMethod)
		{
			UserId = userId;
			ProductId = productId;
			Quantity = quantity;
			Address = address;
			OrderStatus = orderStatus;
			PaymentMethod = paymentMethod;
		}

		public int Id { get; private set; }
		public Guid UserId { get; private set; }
		public Account User { get; private set; }
		public int ProductId { get; private set; }
		public Product Product { get; private set; }
		public int Quantity { get; private set; }
		public string? Address { get; private set; }
		public OrderStatusEnum OrderStatus { get; private set; }
		public PaymentMethodEnum PaymentMethod { get; private set; }
		public bool IsPaid { get; private set; }
		public DateTime? PaidAt { get; private set; }
	}
}
