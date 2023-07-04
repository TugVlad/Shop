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

			await _unitOfWork.BeginTransaction();

			try
			{
				var review = new Review("title", reviewMessage, 5, company);
				company.AddReview(review);
				await _unitOfWork.SaveChangesAsync();

				await _unitOfWork.CommitTransaction();
			}
			catch (Exception)
			{
				await _unitOfWork.RollbackTransaction();
			}

			return company;
		}

		public async Task<bool> DeleteCompanyAsync(int companyId)
		{
			var company = await _companyRepository.GetCompanyByIdAsync(companyId);

			if (company == null)
			{
				return false;
			}

			await _unitOfWork.BeginTransaction();

			try
			{
				_companyRepository.DeleteCompanyAsync(company);
				await _unitOfWork.SaveChangesAsync();

				await _unitOfWork.CommitTransaction();
				return true;
			}
			catch (Exception)
			{
				await _unitOfWork.RollbackTransaction();
			}

			return false;
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
