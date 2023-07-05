using Shop.Core.Models;

namespace Shop.Application.Services.Interfaces
{
	public interface ICompanyService
	{
		Task<List<Company>> GetAllCompaniesAsync();
		Task<List<Company>> GetAllCompaniesWithReviewsAsync();
		Task<Company> GetCompanyByIdAsync(int companyId);
		Task<Company> AddCompanyAsync(Company company);
		Task<Company> AddCompanyReviewAsync(Review review);
		Task<bool> DeleteCompanyAsync(int companyId);
	}
}
