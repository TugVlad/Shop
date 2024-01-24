namespace Shop.Core.Models
{
	public class CartProduct : BaseClass
	{
        public CartProduct()
        {
            SetBaseCreationInfo();
        }

        public int CartId { get; private set; }
        public Cart Cart { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }

        public void UpdateProduct(Product product)
        {
            Product = product;
        }

        public void UpdateQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}
