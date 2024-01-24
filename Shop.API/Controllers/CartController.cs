using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.API.ViewModels.Cart;
using Shop.API.ViewModels.Product;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;

namespace Shop.API.Controllers
{
	[Authorize(AuthenticationSchemes = "Bearer")]
	[Route("api/cart")]
	[ApiController]
	public class CartController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly ICartService _cartService;

		public CartController(IMapper mapper, ICartService cartService)
		{
			_mapper = mapper;
			_cartService = cartService;
		}

		[HttpPost(Name = "AddProductInCart")]
		public async Task<ActionResult> AddProductInCart([FromBody] ProductInCartViewModel productInCart)
		{
			var currentUserId = User.FindFirst("sub")?.Value;
			var response = await _cartService.AddProductToCart(new Guid(currentUserId), _mapper.Map<CartProduct>(productInCart));
			return response != null ? Ok(_mapper.Map<SimpleCartViewModel>(response)) : NotFound("Couldn't add the product in cart!");
		}
	}
}
