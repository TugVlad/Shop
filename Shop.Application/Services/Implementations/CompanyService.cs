using Shop.Application.Repositories.Interfaces;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;

namespace Shop.Application.Services.Implementations
{
	public class CompanyService : BaseService, ICompanyService
	{
		private readonly ICompanyRepository _companyRepository;

		public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
		{
			_companyRepository = companyRepository;
		}

		public async Task<Company> AddCompanyAsync(Company newCompany)
		{
			try
			{
				var company = await _companyRepository.AddCompanyAsync(newCompany);
				await _unitOfWork.SaveChangesAsync();

				return company;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public async Task<Company> AddCompanyReviewAsync(Review review)
		{
			var company = await _companyRepository.GetCompanyReviewsByIdAsync(review.CompanyId.Value);

			if (company == null)
			{
				return null;
			}

			try
			{
				company.AddReview(review);
				await _unitOfWork.SaveChangesAsync();

				return company;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public async Task<bool> DeleteCompanyAsync(int companyId)
		{
			var company = await _companyRepository.GetCompanyByIdAsync(companyId);

			if (company == null)
			{
				return false;
			}

			try
			{
				_companyRepository.DeleteCompanyAsync(company);
				await _unitOfWork.SaveChangesAsync();

				return true;
			}
			catch (Exception)
			{
				return false;
			}

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
