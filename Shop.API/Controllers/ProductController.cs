using Microsoft.AspNetCore.Mvc;
using Shop.Core.Models;
using Shop.Services.Interfaces;

namespace Shop.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService productService;

		public ProductsController(IProductService productService)
		{
			this.productService = productService;
		}

		[HttpGet]
		public async Task<ActionResult> GetAllProducts()
		{
			var products = await productService.GetProductsAsync();
			return Ok(products);
		}

		[HttpGet]
		[Route("productsWithReviews")]
		public async Task<ActionResult> GetAllProductsWithReviews()
		{
			var products = await productService.GetProductsWithReviewsAsync();
			return Ok(products);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetProductById(int id)
		{
			var product = await productService.GetProductByIdAsync(id);
			return product != null ? Ok(product) : NotFound();
		}

		[HttpPost]
		public async Task<ActionResult> AddProduct([FromBody] Product newProduct)
		{
			var product = await productService.AddProductAsync(newProduct);
			return Ok(product);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateProduct(int id, [FromBody] Product newProduct)
		{
			var product = await productService.UpdateProductAsync(id, newProduct);

			if (product == null)
			{
				return NotFound();
			}

			return Ok(product);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var response = await productService.DeleteProductAsync(id);
			return response ? Ok("Product Deleted!") : NotFound();
		}
	}
}
