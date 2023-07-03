using Microsoft.EntityFrameworkCore;
using Shop.Application.Repositories.Interfaces;
using Shop.Core.Models;
using Shop.Data;

namespace Shop.Infrastructure.Repositories.Implementations
{
	public class CompanyRepository : BaseRepository, ICompanyRepository
	{
		public CompanyRepository(ShopContext context) : base(context) { }

		public async Task<Company> AddCompanyAsync(Company company)
		{
			await _context.Companies.AddAsync(company);
			await SaveChangesAsync();
			return company;
		}

		public async Task<bool> DeleteCompanyAsync(Company company)
		{
			_context.Companies.Remove(company);
			await SaveChangesAsync();

			return true;
		}

		public async Task<List<Company>> GetAllCompaniesAsync()
		{
			return await _context.Companies.ToListAsync();
		}

		public async Task<List<Company>> GetAllCompaniesWithReviewsAsync()
		{
			return await _context.Companies.Include(e => e.Reviews).ToListAsync();
		}

		public async Task<Company> GetCompanyByIdAsync(int companyId)
		{
			return await _context.Companies.FirstOrDefaultAsync(e => e.Id == companyId);
		}

		public async Task<Company> GetCompanyReviewsByIdAsync(int companyId)
		{
			return await _context.Companies.Include(e => e.Reviews).FirstOrDefaultAsync(e => e.Id == companyId);
		}
	}
}
