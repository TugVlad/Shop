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
		private readonly IProductInCartRepository _productInCartRepository;

		public OrderService(IOrderRepository orderRepository,
			IProductRepository productRepository,
			IProductInCartRepository productInCartRepository,
			IUnitOfWork unitOfWork) : base(unitOfWork)
		{
			_orderRepository = orderRepository;
			_productRepository = productRepository;
			_productInCartRepository = productInCartRepository;
		}

		public async Task<Order> AddOrderAsync(Order newOrder)
		{
			var prodcutsInCart = await _productInCartRepository.GetProductsInCartForAccountIdAsync(newOrder.UserId);
			if (prodcutsInCart.Count == 0)
			{
				return null;
			}

			var products = await _productRepository.GetProductsByIdsAsync(prodcutsInCart.Select(e => e.ProductId).ToList());
			if (products.Count != prodcutsInCart.Count)
			{
				return null;
			}

			await _unitOfWork.BeginTransaction();
			try
			{
				newOrder.UpdateProductOrdersFromCart(prodcutsInCart);
				var order = await _orderRepository.AddOrderAsync(newOrder);

				products.ForEach(product =>
				{
					var quantity = newOrder.ProductOrders.FirstOrDefault(e => e.ProductId == product.Id)?.Quantity;
					if (quantity == null || product.Quantity < quantity)
					{
						throw new Exception();
					}
					product.DecreaseQuantity(quantity.Value);
				});
				await _unitOfWork.SaveChangesAsync();

				_productInCartRepository.DeleteProductsFromCart(prodcutsInCart);
				await _unitOfWork.SaveChangesAsync();

				await _unitOfWork.CommitTransaction();
				return order;
			}
			catch (Exception)
			{
				await _unitOfWork.RollbackTransaction();
			}

			return null;
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

			await _unitOfWork.BeginTransaction();

			try
			{
				order.UpdatePaymentStatus();
				await _unitOfWork.SaveChangesAsync();

				await _unitOfWork.CommitTransaction();
				return true;
			}
			catch (Exception)
			{
				await _unitOfWork.RollbackTransaction();
			}

			return false;
		}

		public async Task<bool> UpdateShippingForOrderAsync(int orderId, OrderStatusEnum orderStatus)
		{
			var order = await _orderRepository.GetOrderByIdAsync(orderId);

			if (order == null || order.OrderStatus == orderStatus || order.IsPaid == false)
			{
				return false;
			}

			await _unitOfWork.BeginTransaction();

			try
			{
				order.UpdateStatus(orderStatus);
				await _unitOfWork.SaveChangesAsync();

				await _unitOfWork.CommitTransaction();
				return true;
			}
			catch (Exception)
			{
				await _unitOfWork.RollbackTransaction();
			}

			return false;
		}

		public async Task<Order> GetOrderInformation(int orderId)
		{
			return await _orderRepository.GetOrderWithDependenciesByIdAsync(orderId);
		}
	}
}
