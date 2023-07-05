namespace Shop.API.ViewModels.Product
{
	public class AddProductReviewViewModel
	{
		public int? ProductId { get; set; }

		public string Title { get; set; }

		public string Content { get; set; }

		public float Score { get; set; }
	}
}
