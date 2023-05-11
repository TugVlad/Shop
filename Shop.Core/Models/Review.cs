namespace Shop.Core.Models
{
	public class Review
	{
		public int Id { get; private set; }
		public string Title { get; private set; }
		public string Content { get; private set; }
		public float Score { get; private set; }
		public int ProductId { get; private set; }
		public Product Product { get; private set; }
	}
}
