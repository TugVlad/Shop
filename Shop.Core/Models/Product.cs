using Shop.Enums;

namespace Shop.Core.Models
{
	public class Product
	{
		public Product()
		{
		}

		public int Id { get; private set; }

		public string Name { get; private set; }

		public string Description { get; private set; }

		public ProductTypeEnum Type { get; private set; }

		public decimal Price { get; private set; }

		public int Quantity { get; private set; }

		public List<Review> Reviews { get; private set; } = new();

		public List<CompanyProduct> CompanyProducts { get; private set; } = new();

		public void UpdateName(string name)
		{
			Name = name;
		}

		public void UpdateDescription(string description)
		{
			Description = description;
		}

		public void UpdateType(ProductTypeEnum type)
		{
			Type = type;
		}

		public void UpdatePrice(decimal price)
		{
			Price = price;
		}

		public void UpdateQuantity(int quantity)
		{
			Quantity = quantity;
		}

		public void IncreaseQuantity(int quantity)
		{
			Quantity += quantity;
		}

		public void DecreaseQuantity(int quantity)
		{
			Quantity -= quantity;
		}

		public void AddReview(Review review)
		{
			Reviews.Add(review);
		}

		public void AddCompany(int companyId)
		{
			CompanyProducts.Add(new CompanyProduct(companyId, Id));
		}
	}
}
