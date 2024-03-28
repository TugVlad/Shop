using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Services;
using Shop.API.ViewModels.HATEOAS;
using Shop.API.ViewModels.Order;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;

namespace Shop.API.Controllers
{
	[Authorize(AuthenticationSchemes = "Bearer")]
	[Route("api/orders")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IOrderService _orderService;
		private readonly IHATEOASService _hateoasService;

		public OrderController(IMapper mapper, IOrderService orderService, IHATEOASService hateoasService)
		{
			_mapper = mapper;
			_orderService = orderService;
			_hateoasService = hateoasService;
		}

		//[Authorize(Policy = "IsAdmin")]
		[HttpGet(Name = "GetAllOrders")]
		public async Task<ActionResult> GetAllOrders()
		{
			var orders = await _orderService.GetAllOrdersAsync();

			var mappedResult = _mapper.Map<List<OrderViewModel>>(orders);
			var hateoasResult = new HATEOASExtension<List<OrderViewModel>>(mappedResult);
			hateoasResult.Links = _hateoasService.GetLinks(new List<LinkDetails>()
			{
				new LinkDetails("GetAllOrders","SELF"),
				new LinkDetails("AddOrder","POST"),
				new LinkDetails("GetOrderById","GET",0),
				new LinkDetails("CompleteShippment","POST",0),
				new LinkDetails("PayForOrderById","POST",0),
			});

			return Ok(hateoasResult);
		}

		[HttpPost(Name = "AddOrder")]
		public async Task<ActionResult> AddOrder([FromBody] AddOrderViewModel order)
		{
			var currentUserId = User.FindFirst("sub")?.Value;
			var orderInfo = await _orderService.AddOrderAsync(new Guid(currentUserId), _mapper.Map<Order>(order));

			if (orderInfo == null)
			{
				return BadRequest("Could not add order!");
			}

			var mappedResult = _mapper.Map<OrderViewModel>(orderInfo);
			var hateoasResult = new HATEOASExtension<OrderViewModel>(mappedResult);
			hateoasResult.Links = _hateoasService.GetLinks(new List<LinkDetails>()
			{
				new LinkDetails("AddOrder","SELF"),
				new LinkDetails("GetOrderById","GET",0),
				new LinkDetails("PayForOrderById","POST",0),
				new LinkDetails("GetAllProducts","GET"),
				new LinkDetails("GetAllProductsDetails","GET"),
			});

			return Ok(hateoasResult);
		}

		[HttpGet]
		[Route("{orderId}", Name = "GetOrderById")]
		public async Task<ActionResult> GetOrder([FromRoute] int orderId)
		{
			var result = await _orderService.GetOrderInformation(orderId);

			if (result == null)
			{
				return NotFound("Order not found!");
			}

			var mappedResult = _mapper.Map<OrderViewModel>(result);
			var hateoasResult = new HATEOASExtension<OrderViewModel>(mappedResult);
			hateoasResult.Links = _hateoasService.GetLinks(new List<LinkDetails>()
			{
				new LinkDetails("AddOrder","POST"),
				new LinkDetails("GetOrderById","SELF",orderId),
				new LinkDetails("PayForOrderById","POST",orderId),
			});

			return result != null ? Ok(_mapper.Map<OrderViewModel>(result)) : NotFound("Order not found!");
		}
	}
}
