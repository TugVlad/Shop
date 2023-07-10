using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.API.ViewModels.Order;
using Shop.Application.Services.Interfaces;
using Shop.Core.Enums;
using Shop.Core.Models;

namespace Shop.API.Controllers
{
	[Route("api/orders")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IOrderService _orderService;

		public OrderController(IMapper mapper, IOrderService orderService)
		{
			_mapper = mapper;
			_orderService = orderService;
		}

		[HttpGet]
		public async Task<ActionResult> GetAllOrders()
		{
			var orders = await _orderService.GetAllOrdersAsync();
			return Ok(_mapper.Map<List<OrderViewModel>>(orders));
		}

		[HttpPost]
		public async Task<ActionResult> AddOrder([FromBody] AddOrderViewModel order)
		{
			var orderInfo = await _orderService.AddOrderAsync(_mapper.Map<Order>(order));
			return orderInfo != null ? Ok(_mapper.Map<OrderViewModel>(orderInfo)) : BadRequest("Could not add order!");
		}

		[HttpGet]
		[Route("{orderId}")]
		public async Task<ActionResult> GetOrder([FromRoute] int orderId)
		{
			var result = await _orderService.GetOrderInformation(orderId);
			return result != null ? Ok(_mapper.Map<OrderViewModel>(result)) : NotFound("Order not found!");
		}
	}
}
