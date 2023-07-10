using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.API.ViewModels.Product;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;

namespace Shop.API.Controllers
{
	[Route("api/products")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IProductService _productService;

		public ProductsController(IMapper mapper, IProductService productService)
		{
			_mapper = mapper;
			_productService = productService;
		}

		[HttpGet]
		public async Task<ActionResult> GetAllProducts()
		{
			var products = await _productService.GetProductsAsync();
			return Ok(_mapper.Map<List<ProductViewModel>>(products));
		}

		[HttpGet]
		[Route("details")]
		public async Task<ActionResult> GetAllProductsWithCompleteInformation()
		{
			var products = await _productService.GetProductsCompleteInformationAsync();
			return Ok(_mapper.Map<List<ProductViewModel>>(products));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetProductById(int id)
		{
			var product = await _productService.GetProductByIdAsync(id);
			return product != null ? Ok(_mapper.Map<ProductViewModel>(product)) : NotFound("Couldn't find the product!");
		}

		[HttpPost]
		public async Task<ActionResult> AddProduct([FromBody] AddProductViewModel newProduct)
		{
			var product = await _productService.AddProductAsync(_mapper.Map<Product>(newProduct));
			return Ok(_mapper.Map<ProductViewModel>(product));
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateProduct(int id, [FromBody] AddProductViewModel newProduct)
		{
			var product = await _productService.UpdateProductAsync(id, _mapper.Map<Product>(newProduct));

			if (product == null)
			{
				return NotFound("Couldn't update the product!");
			}

			return Ok(_mapper.Map<ProductViewModel>(product));
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var response = await _productService.DeleteProductAsync(id);
			return response ? Ok("Product Deleted!") : NotFound("Couldn't delete the product!");
		}
	}
}
