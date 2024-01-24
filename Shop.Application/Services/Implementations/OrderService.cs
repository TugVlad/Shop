using Shop.Application.Repositories.Interfaces;
using Shop.Application.Services.Interfaces;
using Shop.Core.Enums;
using Shop.Core.Models;

namespace Shop.Application.Services.Implementations
{
	public class OrderService : BaseService, IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IProductRepository _productRepository;
		private readonly ICartRepository _productInCartRepository;

		public OrderService(IOrderRepository orderRepository,
			IProductRepository productRepository,
			ICartRepository productInCartRepository,
			IUnitOfWork unitOfWork) : base(unitOfWork)
		{
			_orderRepository = orderRepository;
			_productRepository = productRepository;
			_productInCartRepository = productInCartRepository;
		}

		public async Task<Order> AddOrderAsync(Order newOrder)
		{
			var prodcutsInCart = await _productInCartRepository.GetCartProductsByAccountIdAsync(newOrder.UserId);
			if (prodcutsInCart.Count == 0)
			{
				return null;
			}

			var products = await _productRepository.GetProductsByIdsAsync(prodcutsInCart.Select(e => e.ProductId).ToList());
			if (products.Count != prodcutsInCart.Count)
			{
				return null;
			}

			await _unitOfWork.BeginTransactionAsync();
			try
			{
				newOrder.UpdateProductOrdersFromCart(prodcutsInCart);
				var order = await _orderRepository.AddOrderAsync(newOrder);

				products.ForEach(product =>
				{
					var quantity = newOrder.ProductOrders.FirstOrDefault(e => e.ProductId == product.Id)?.Quantity;
					product.DecreaseQuantity(quantity.Value);
				});

				_productInCartRepository.DeleteProductsFromCart(prodcutsInCart);

				await _unitOfWork.SaveChangesAsync();
				await _unitOfWork.CommitTransactionAsync();
				return order;
			}
			catch (Exception)
			{
				await _unitOfWork.RollbackTransactionAsync();
				return null;
			}
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

			try
			{
				order.UpdatePaymentStatus();
				await _unitOfWork.SaveChangesAsync();

				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public async Task<bool> UpdateShippingForOrderAsync(int orderId, OrderStatusEnum orderStatus)
		{
			var order = await _orderRepository.GetOrderByIdAsync(orderId);

			if (order == null || order.OrderStatus == orderStatus || order.IsPaid == false)
			{
				return false;
			}

			try
			{
				order.UpdateStatus(orderStatus);
				await _unitOfWork.SaveChangesAsync();

				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public async Task<Order> GetOrderInformation(int orderId)
		{
			return await _orderRepository.GetOrderWithDependenciesByIdAsync(orderId);
		}
	}
}
