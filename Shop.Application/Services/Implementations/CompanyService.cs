using Shop.Application.Repositories.Interfaces;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;
using Shop.Core.ViewModels;

namespace Shop.Application.Services.Implementations
{
	public class CompanyService : ICompanyService
	{
		private readonly ICompanyRepository companyRepository;

		public CompanyService(ICompanyRepository companyRepository)
		{
			this.companyRepository = companyRepository;
		}

		public async Task<Company> AddCompanyAsync(CompanyViewModel company)
		{
			return await companyRepository.AddCompanyAsync(new Company(company));
		}

		public async Task<Company> AddCompanyReviewAsync(int companyId, string reviewMessage)
		{
			var company = await companyRepository.GetCompanyReviewsByIdAsync(companyId);

			if (company == null)
			{
				return null;
			}

			var review = new Review("title", reviewMessage, 5, company);

			return await companyRepository.AddCompanyReviewAsync(company,review);
		}

		public async Task<bool> DeleteCompanyAsync(int companyId)
		{
			return await companyRepository.DeleteCompanyAsync(companyId);
		}

		public async Task<List<Company>> GetAllCompaniesAsync()
		{
			return await companyRepository.GetAllCompaniesAsync();
		}

		public async Task<List<Company>> GetAllCompaniesWithReviewsAsync()
		{
			return await companyRepository.GetAllCompaniesWithReviewsAsync();
		}

		public async Task<Company> GetCompanyByIdAsync(int companyId)
		{
			return await companyRepository.GetCompanyByIdAsync(companyId);
		}
	}
}
