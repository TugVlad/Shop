using Shop.Application.Repositories.Interfaces;
using Shop.Application.Services.Interfaces;
using Shop.Core.Enums;
using Shop.Core.Models;

namespace Shop.Application.Services.Implementations
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IProductService _productService;

		public OrderService(IOrderRepository orderRepository, IProductService productRepository)
		{
			_orderRepository = orderRepository;
			_productService = productRepository;
		}

		public async Task<Order> AddOrderAsync(Order order)
		{
			if (!await _productService.CheckIfProductsExistAsync(order.ProductOrders.Select(e => e.ProductId).ToList()))
			{
				return null;
			}

			order.UpdateOrderId();
			return await _orderRepository.AddOrderAsync(order);
		}

		public async Task<List<Order>> GetAllOrdersAsync()
		{
			return await _orderRepository.GetAllOrdersAsync();
		}

		public async Task<bool> PayForOrderAsync(int orderId)
		{
			var order = await _orderRepository.GetOrderByIdAsync(orderId);

			if (order == null || order.IsPaid == true)
			{
				return false;
			}

			order.UpdatePaymentStatus();
			await _orderRepository.SaveChangesAsync();
			return true;
		}

		public async Task<bool> UpdateShippingForOrderAsync(int orderId, OrderStatusEnum orderStatus)
		{
			var order = await _orderRepository.GetOrderByIdAsync(orderId);

			if (order == null || order.OrderStatus == orderStatus || order.IsPaid == false)
			{
				return false;
			}

			order.UpdateStatus(orderStatus);
			await _orderRepository.SaveChangesAsync();
			return true;
		}

		public async Task<Order> GetOrderInformation(int orderId)
		{
			var order = await _orderRepository.GetOrderWithDependenciesByIdAsync(orderId);

			if (order == null)
			{
				return null;
			}

			return order;
		}
	}
}
