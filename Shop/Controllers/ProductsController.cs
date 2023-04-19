using Microsoft.AspNetCore.Mvc;
using Shop.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private List<Product> products;

		public ProductsController()
		{
			products = new List<Product> {
				new Product
					{
						Id = 1,
						Name = "Product1",
						Type = Enums.ProductTypeEnum.Telefon,
						Description = "Description1",
						Price = 10
					},
				new Product
					{
						Id = 2,
						Name = "Product2",
						Type = Enums.ProductTypeEnum.Tableta,
						Description = "Description2",
						Price = 20
					},
				new Product
					{
						Id = 3,
						Name = "Product3",
						Type = Enums.ProductTypeEnum.Televizor,
						Description = "Description3",
						Price = 30
					},
			};
		}

		[HttpGet]
		public ActionResult Get()
		{
			return Ok(products);
		}

		[HttpGet("{id}")]
		public ActionResult Get(int id)
		{
			var product = products.FirstOrDefault(e => e.Id == id);
			return product != null ? Ok(product) : NotFound();
		}

		[HttpPost]
		public ActionResult Post([FromBody] Product product)
		{
			products.Add(product);
			return Ok(product);
		}

		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] decimal value)
		{
			var product = products.FirstOrDefault(e => e.Id == id);

			if (product == null)
			{
				return NotFound();
			}

			product.Price = value;
			return Ok(product);
		}

		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			var product = products.FirstOrDefault(e => e.Id == id);

			if (product == null)
			{
				return NotFound();
			}

			products.Remove(product);
			return Ok("Product Deleted!");
		}
	}
}
