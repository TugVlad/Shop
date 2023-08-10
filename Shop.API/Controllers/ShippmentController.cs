using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Services.Interfaces;
using Shop.Core.Enums;

namespace Shop.API.Controllers
{
	[Authorize(Policy = "IsAdmin")]
	[Route("api/shippments")]
	[ApiController]
	public class ShippmentController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public ShippmentController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpPost]
		[Route("completion/order/{orderId}", Name = "CompleteShippment")]
		public async Task<ActionResult> ShippmentComplete([FromRoute] int orderId)
		{
			var result = await _orderService.UpdateShippingForOrderAsync(orderId, OrderStatusEnum.ProductsDelivered);
			return result ? Ok("Shippment finished") : NotFound("Couldn't complete the shippment!");
		}
	}
}
