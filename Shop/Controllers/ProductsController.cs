using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.Controllers
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
			var products = await productService.GetProducts();
			return Ok(products);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetProductById(int id)
		{
			var product = await productService.GetProductById(id);
			return product != null ? Ok(product) : NotFound();
		}

		[HttpPost]
		public async Task<ActionResult> AddProduct([FromBody] Product newProduct)
		{
			var product = await productService.AddProduct(newProduct);
			return Ok(product);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateProduct(int id, [FromBody] Product newProduct)
		{
			var product = await productService.UpdateProduct(id, newProduct);

			if (product == null)
			{
				return NotFound();
			}

			return Ok(product);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var response = await productService.DeleteProduct(id);
			return response ? Ok("Product Deleted!") : NotFound();
		}
	}
}
