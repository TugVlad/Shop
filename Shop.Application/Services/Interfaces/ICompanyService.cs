using Shop.Core.Models;
using Shop.Core.ViewModels;

namespace Shop.Application.Services.Interfaces
{
	public interface ICompanyService
	{
		Task<List<Company>> GetAllCompaniesAsync();
		Task<List<Company>> GetAllCompaniesWithReviewsAsync();
		Task<Company> GetCompanyByIdAsync(int companyId);
		Task<Company> AddCompanyAsync(CompanyViewModel company);
		Task<Company> AddCompanyReviewAsync(int companyId, string reviewMessage);
		Task<bool> DeleteCompanyAsync(int companyId);
	}
}
