using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Services.Interfaces;

namespace Shop.API.Controllers
{
	[Authorize]
	[Route("api/payments")]
	[ApiController]
	public class PaymentController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public PaymentController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpPost]
		[Route("order/{orderId}")]
		public async Task<ActionResult> PayForOrder([FromRoute] int orderId)
		{
			var result = await _orderService.PayForOrderAsync(orderId);
			return result ? Ok("Payment succeeded") : NotFound("Payment failed!");
		}
	}
}
