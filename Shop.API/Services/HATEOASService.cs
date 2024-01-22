using Shop.API.ViewModels.HATEOAS;

namespace Shop.API.Services
{
	public class HATEOASService : IHATEOASService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly LinkGenerator _linkGenerator;
		private List<Link> _links;

		public HATEOASService(IHttpContextAccessor httpContextAccessor, LinkGenerator linkGenerator)
        {
			_httpContextAccessor = httpContextAccessor;
			_linkGenerator = linkGenerator;
			_links = new();
		}

		public List<Link> GetCompanyLinks(int? id = null)
		{
			_links.Add(GenerateLink("GetAllCompanies", "GetAllCompanies","Get"));
			_links.Add(GenerateLink("GetAllCompaniesDetails", "GetAllCompaniesDetails", "Get"));
			_links.Add(GenerateLink("GetCompanyById", "GetCompanyById", "Get", id));
			_links.Add(GenerateLink("AddCompany", "AddCompany", "Post"));
			_links.Add(GenerateLink("DeleteCompany", "DeleteCompany", "Delete", id));

			return _links;
		}

		public List<Link> GetLinks(List<LinkDetails> details)
		{
			foreach(var detail in details)
			{
				_links.Add(GenerateLink(detail.RouteName, detail.RouteName, detail.Method, detail.Id));
			}

			return _links;
		}

		private Link GenerateLink(string routeName, string rel, string method, int? id = null)
		{
			return id == null ? new Link(_linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, routeName), rel, method):
				new Link(_linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, routeName, new { id }), rel, method);
		}
	}
}
