using Shop.Enums;

namespace Shop.API.ViewModels
{
	public class ProductViewModel
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public ProductTypeEnum Type { get; set; }

		public decimal Price { get; set; }

		public int Quantity { get; set; }

		public int? CompanyId { get; set; }
	}
}
