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

		public List<Product> Products { get; private set; } = new();

		public void AddReview(Review review)
		{
			Reviews.Add(review);
		}

		public void AddProduct(Product product)
		{
			Products.Add(product);
		}
	}
}
