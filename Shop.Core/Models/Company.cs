namespace Shop.Core.Models
{
	public class Company
	{
		public Company()
		{

		}

		public int Id { get; private set; }

		public string Name { get; private set; }

		public string Address { get; private set; }

		public List<Review> Reviews { get; private set; }

		public List<Product> Products { get; private set; }
	}
}
