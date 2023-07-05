namespace Shop.API.ViewModels.Product
{
	public class ProductInCartViewModel
	{
		public Guid AccountId { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }
	}
}
