using Shop.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
	public class Product
	{
		public int Id { get; private set; }

		[Required]
		[Column(TypeName = "varchar(251)")]
		public string Name { get; private set; }

		[Column(TypeName = "varchar(500)")]
		public string Description { get; private set; }

		[Required]
		[Column(TypeName = "nvarchar(50)")]
		public ProductTypeEnum Type { get; private set; }

		[Column(TypeName = "decimal(5, 2)")]
		public decimal Price { get; private set; }

		public void UpdateProduct(Product product)
		{
			Name = product.Name;
			Description = product.Description;
			Price = product.Price;
			Type = product.Type;
		}

	}
}
