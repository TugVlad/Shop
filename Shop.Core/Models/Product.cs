using Shop.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
	public class Product
	{
		public int Id { get; set; }

		[Required]
		[Column(TypeName = "varchar(251)")]
		public string Name { get; set; }

		[Column(TypeName = "varchar(500)")]
		public string Description { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(50)")]
		public ProductTypeEnum Type { get; set; }

		[Column(TypeName = "decimal(5, 2)")]
		public decimal Price { get; set; }

		public void UpdateProduct(Product product)
		{
			Name = product.Name;
			Description = product.Description;
			Price = product.Price;
			Type = product.Type;
		}

	}
}
