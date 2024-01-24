namespace Shop.Core.Models
{
	public class Cart : BaseClass
	{
        public Cart(Guid accountId)
        {
            AccountId = accountId;
			TotalPrice = 0;
        }

        public int Id { get; private set; }
        public Guid AccountId { get; private set; }
		public Account? Account { get; private set; }
		public decimal TotalPrice { get; private set; }
        public List<CartProduct> CartProducts { get; private set; } = new();

		public void AddProduct(CartProduct product)
		{
			CartProducts.Add(product);
			IncreasePrice(product.Product.Price, product.Quantity);
			UpdateBaseInfo(AccountId);
		}

		public void RemoveProduct(CartProduct product)
		{
			CartProducts.Remove(product);
			DecreasePrice(product.Product.Price, product.Quantity);
			UpdateBaseInfo(AccountId);
		}

		public void UpdateProduct(CartProduct product, int newQuantity)
		{
			if (product.Quantity > newQuantity)
			{
				DecreasePrice(product.Product.Price, product.Quantity - newQuantity);
			}
			else
			{
				IncreasePrice(product.Product.Price, newQuantity - product.Quantity);
			}
			product.UpdateQuantity(newQuantity);
		}

		private void IncreasePrice(decimal price, int quantity) 
		{
			TotalPrice += price * quantity;
		}

		private void DecreasePrice(decimal price, int quantity)
		{
			TotalPrice -= price * quantity;
		}
	}
}
