namespace Shop.API.ViewModels.Company
{
	public class CompanyReviewViewModel
	{
		public int Id { get; set; }
		public int? CompanyId { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public float Score { get; set; }
	}
}
