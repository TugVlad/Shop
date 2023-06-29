namespace Shop.Core.Models
{
	public class Review : BaseClass
	{
		public Review()
		{
			SetBaseCreationInfo();
		}

		public Review(string title, string content, float score, Product product)
		{
			SetBaseCreationInfo();
			Title = title;
			Content = content;
			Score = score;
			Product = product;
		}

		public Review(string title, string content, float score, Company company)
		{
			SetBaseCreationInfo();
			Title = title;
			Content = content;
			Score = score;
			Company = company;
		}

		public int Id { get; private set; }

		public string Title { get; private set; }

		public string Content { get; private set; }

		public float Score { get; private set; }

		public int? ProductId { get; private set; }

		public Product Product { get; private set; }

		public int? CompanyId { get; private set; }

		public Company Company { get; private set; }
	}
}
