namespace Shop.Core.Models
{
	public class ProductOrder
	{
		public ProductOrder() { }

		public ProductOrder(int productId, int orderId, int quantity)
		{
			ProductId = productId;
			OrderId = orderId;
			Quantity = quantity;
		}

		public int ProductId { get; private set; }
		public Product Product { get; private set; }
		public int OrderId { get; private set; }
		public Order Order { get; private set; }
		public int Quantity { get; private set; }

		public void UpdateOrderId(int orderId)
		{
			OrderId = orderId;
		}
	}
}
