using Shop.API.ViewModels.Company;
using Shop.Enums;

namespace Shop.API.ViewModels.Product
{
	public class ProductViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public ProductTypeEnum Type { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public CompanyViewModel Company { get; set; }
		public List<ProductReviewViewModel> Reviews { get; set; }
	}
}
