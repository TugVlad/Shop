namespace Shop.Core.Models
{
	public class CompanyProduct
	{
        public CompanyProduct()
        {   
        }

        public CompanyProduct(int companyId, int productId)
        {
            CompanyId = companyId;
            ProductId = productId;
        }

        public int CompanyId { get; private set; }
		public Company Company { get; private set; }

		public int ProductId { get; private set; }
		public Product Product { get; private set; }
	}
}
