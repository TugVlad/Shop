using Shop.Core.Models;

namespace Shop.Application.Repositories.Interfaces
{
	public interface ICompanyRepository
	{
		Task<List<Company>> GetAllCompaniesAsync();
		Task<List<Company>> GetAllCompaniesWithReviewsAsync();
		Task<Company> GetCompanyByIdAsync(int companyId);
		Task<Company> GetCompanyReviewsByIdAsync(int companyId);
		Task<Company> AddCompanyAsync(Company company);
		Task<Company> AddCompanyReviewAsync(Company company, Review review);
		Task<bool> DeleteCompanyAsync(int companyId);
	}
}
