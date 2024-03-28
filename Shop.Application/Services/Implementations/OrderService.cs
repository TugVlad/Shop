using Shop.Application.Repositories.Interfaces;
using Shop.Application.Services.Interfaces;
using Shop.Application.Strategies.Implementation;
using Shop.Application.Strategies.Interfaces;
using Shop.Core.Enums;
using Shop.Core.Models;

namespace Shop.Application.Services.Implementations
{
	public class OrderService : BaseService, IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IProductRepository _productRepository;
		private readonly ICartRepository _productInCartRepository;

		private IPaymentStrategy _paymentStrategy;

		public OrderService(IOrderRepository orderRepository,
			IProductRepository productRepository,
			ICartRepository productInCartRepository,
			IUnitOfWork unitOfWork) : base(unitOfWork)
		{
			_orderRepository = orderRepository;
			_productRepository = productRepository;
			_productInCartRepository = productInCartRepository;
		}

		public async Task<Order> AddOrderAsync(Guid userId, Order newOrder)
		{
			var prodcutsInCart = await _productInCartRepository.GetCartProductsByAccountIdAsync(userId);
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
				newOrder.UpdateUserId(userId);
				var order = await _orderRepository.AddOrderAsync(newOrder);

				products.ForEach(product =>
				{
					var quantity = newOrder.ProductOrders.FirstOrDefault(e => e.ProductId == product.Id)?.Quantity;
					product.DecreaseQuantity(quantity.Value);
				});

				_productInCartRepository.DeleteProductsFromCart(prodcutsInCart);
				//TODO -> reset cart value after adding order

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
				SetStrategy(order.PaymentMethod);
				_paymentStrategy.Execute();

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

		private void SetStrategy(PaymentMethodEnum paymentMethod)
		{
			switch (paymentMethod)
			{
				case (PaymentMethodEnum.Card):
					{
						_paymentStrategy = new OnlineCardPaymentStrategy();
					}
					break;

				case (PaymentMethodEnum.GiftCard):
					{
						_paymentStrategy = new GiftCardPaymentStrategy();
					}
					break;

				case (PaymentMethodEnum.CashOnDelivery):
					{
						_paymentStrategy = new CashOnDeliveryPaymentStrategy();
					}
					break;
			}
		}
	}
}
