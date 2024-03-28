using Shop.Core.Enums;
using System.Data;

namespace Shop.Core.Models
{
	public class Order : BaseClass
	{
		public Order()
		{
			SetBaseCreationInfo();
		}

		public Order(Guid userId, string address, OrderStatusEnum orderStatus, PaymentMethodEnum paymentMethod)
		{
			SetBaseCreationInfo();
			UserId = userId;
			Address = address;
			OrderStatus = orderStatus;
			PaymentMethod = paymentMethod;
		}

		public int Id { get; private set; }
		public Guid UserId { get; private set; }
		public Account User { get; private set; }
		public List<ProductOrder> ProductOrders { get; private set; } = new();
		public string? Address { get; private set; }
		public OrderStatusEnum OrderStatus { get; private set; }
		public PaymentMethodEnum PaymentMethod { get; private set; }
		public bool IsPaid { get; private set; }
		public DateTime? PaidAt { get; private set; }

		public void UpdateProductOrdersFromCart(List<CartProduct> productInCarts)
		{
			productInCarts.ForEach(productInCart =>
			{
				ProductOrders.Add(new ProductOrder(productInCart.ProductId, Id, productInCart.Quantity));
			});
		}

		public void UpdatePaymentStatus()
		{
			OrderStatus = OrderStatusEnum.OrderPlaced;
			IsPaid = true;
			PaidAt = DateTime.Now;
			UpdateBaseInfo();
		}

		public void UpdateStatus(OrderStatusEnum orderStatus)
		{
			OrderStatus = orderStatus;
			UpdateBaseInfo();
		}

		public void UpdateUserId(Guid userId)
		{
			UserId = userId;
		}
	}
}
