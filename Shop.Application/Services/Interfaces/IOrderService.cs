using Shop.Core.Enums;
using Shop.Core.Models;

namespace Shop.Application.Services.Interfaces
{
	public interface IOrderService
	{
		Task<List<Order>> GetAllOrdersAsync();
		Task<Order> AddOrderAsync(Order order);
		Task<bool> PayForOrderAsync(int orderId);
		Task<bool> UpdateShippingForOrderAsync(int orderId, OrderStatusEnum orderStatus);
		Task<Order> GetOrderInformation(int orderId);
	}
}
