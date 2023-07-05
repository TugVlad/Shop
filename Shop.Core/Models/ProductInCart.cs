namespace Shop.Core.Models
{
	public class ProductInCart : BaseClass
	{
        public ProductInCart()
        {
            SetBaseCreationInfo();
        }

        public Guid AccountId { get; private set; }
        public Account Account { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
    }
}
