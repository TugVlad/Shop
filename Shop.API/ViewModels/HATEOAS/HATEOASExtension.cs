namespace Shop.API.ViewModels.HATEOAS
{
	public class HATEOASExtension<T>
	{
		public HATEOASExtension(T content)
		{
			Content = content;
		}

		public T Content { get; set; }
		public List<Link> Links { get; set; } = new();
	}
}
