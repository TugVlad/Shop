namespace Shop.Core.Models
{
	public class Company : BaseClass
	{
		public Company()
		{
			SetBaseCreationInfo();
		}

		public int Id { get; private set; }

		public string Name { get; private set; }

		public string Address { get; private set; }

		public List<Review> Reviews { get; private set; } = new();

		public List<CompanyProduct> CompanyProducts { get; private set; } = new();

		public void AddReview(Review review)
		{
			Reviews.Add(review);
		}

		public void AddProduct(Product product)
		{
			CompanyProducts.Add(new CompanyProduct(Id, product.Id));
		}
	}
}
