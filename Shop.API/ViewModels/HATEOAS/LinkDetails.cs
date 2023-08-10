namespace Shop.API.ViewModels.HATEOAS
{
	public class LinkDetails
	{
		public LinkDetails(string routeName, string method, int? id = null) 
		{ 
			RouteName = routeName;
			Method = method;
			Id = id;
		}

		public string RouteName { get; set; }
		public string Method { get; set; }
		public int? Id { get; set; }
	}
}
