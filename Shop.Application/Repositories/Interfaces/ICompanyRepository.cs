using Shop.Core.Models;

namespace Shop.Application.Repositories.Interfaces
{
	public interface ICompanyRepository : IBaseRepository
	{
		Task<List<Company>> GetAllCompaniesAsync();
		Task<List<Company>> GetAllCompaniesWithReviewsAsync();
		Task<Company> GetCompanyByIdAsync(int companyId);
		Task<Company> GetCompanyReviewsByIdAsync(int companyId);
		Task<Company> AddCompanyAsync(Company company);
		void DeleteCompanyAsync(Company company);
	}
}
