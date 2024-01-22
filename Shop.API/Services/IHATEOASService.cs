using Shop.API.ViewModels.HATEOAS;

namespace Shop.API.Services
{
	public interface IHATEOASService
	{
		List<Link> GetCompanyLinks(int? id = null);
		List<Link> GetLinks(List<LinkDetails> details);
	}
}
