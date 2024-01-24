using Shop.Enums;

namespace Shop.Core.Models
{
	public class Product : BaseClass
	{
		public Product()
		{
			SetBaseCreationInfo();
		}

		public int Id { get; private set; }

		public string Name { get; private set; }

		public string Description { get; private set; }

		public ProductTypeEnum Type { get; private set; }

		public decimal Price { get; private set; }

		public int Quantity { get; private set; }

		public List<Review> Reviews { get; private set; } = new();

		public int? CompanyId { get; private set; }

		public Company Company { get; private set; }

		public List<ProductOrder> ProductOrders { get; private set; } = new();

		public List<CartProduct> CartProducts { get; private set; } = new();


		public void UpdateProduct(Product product)
		{
			Name = product.Name;
			Description= product.Description;
			Type = product.Type;
			Price = product.Price;
			Quantity = product.Quantity;
			CompanyId = product.CompanyId;
		}

		public void DecreaseQuantity(int quantity)
		{
			if (quantity == 0 || Quantity < quantity)
			{
				throw new Exception();
			}

			Quantity -= quantity;
		}

		public void AddReview(Review review)
		{
			Reviews.Add(review);
		}
	}
}
