using Shop.Application.Repositories.Interfaces;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;

namespace Shop.Application.Services.Implementations
{
	public class CompanyService : ICompanyService
	{
		private readonly ICompanyRepository _companyRepository;

		public CompanyService(ICompanyRepository companyRepository)
		{
			_companyRepository = companyRepository;
		}

		public async Task<Company> AddCompanyAsync(Company company)
		{
			return await _companyRepository.AddCompanyAsync(company);
		}

		//TODO -> make this properly
		public async Task<Company> AddCompanyReviewAsync(int companyId, string reviewMessage)
		{
			var company = await _companyRepository.GetCompanyReviewsByIdAsync(companyId);

			if (company == null)
			{
				return null;
			}

			var review = new Review("title", reviewMessage, 5, company);
			company.AddReview(review);
			await _companyRepository.SaveChangesAsync();

			return company;
		}

		public async Task<bool> DeleteCompanyAsync(int companyId)
		{
			var company = await _companyRepository.GetCompanyByIdAsync(companyId);

			if (company == null)
			{
				return false;
			}

			return await _companyRepository.DeleteCompanyAsync(company);
		}

		public async Task<List<Company>> GetAllCompaniesAsync()
		{
			return await _companyRepository.GetAllCompaniesAsync();
		}

		public async Task<List<Company>> GetAllCompaniesWithReviewsAsync()
		{
			return await _companyRepository.GetAllCompaniesWithReviewsAsync();
		}

		public async Task<Company> GetCompanyByIdAsync(int companyId)
		{
			return await _companyRepository.GetCompanyByIdAsync(companyId);
		}
	}
}
