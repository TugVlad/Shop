using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.API.ViewModels.Product;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;

namespace Shop.API.Controllers
{
	[Authorize]
	[Route("api/cart-products")]
	[ApiController]
	public class ProductInCartController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IProductService _productService;

		public ProductInCartController(IMapper mapper, IProductService productService)
		{
			_mapper = mapper;
			_productService = productService;
		}

		[HttpPost]
		public async Task<ActionResult> AddProductInCart([FromBody] ProductInCartViewModel productInCart)
		{
			var response = await _productService.AddProductInCart(_mapper.Map<ProductInCart>(productInCart));
			return response ? Ok("Product added in cart!") : NotFound("Couldn't add the product in cart!");
		}
	}
}
