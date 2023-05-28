using Microsoft.EntityFrameworkCore;
using Shop.Application.Repositories.Interfaces;
using Shop.Core.Models;
using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories.Implementations
{
	public class CompanyRepository : ICompanyRepository
	{
		private readonly ShopContext _context;

		public CompanyRepository(ShopContext shopContext)
		{
			_context = shopContext;
		}

		public async Task<Company> AddCompanyAsync(Company company)
		{
			await _context.Companies.AddAsync(company);
			await SaveChangesAsync();
			return company;
		}

		public async Task<Company> AddCompanyReviewAsync(Company company, Review review)
		{
			company.Reviews.Add(review);
			await SaveChangesAsync();

			return company;
		}

		public async Task<bool> DeleteCompanyAsync(int companyId)
		{
			var company = await _context.Companies.FirstOrDefaultAsync(e => e.Id == companyId);

			if (company == null)
			{
				return false;
			}

			_context.Companies.Remove(company);
			await SaveChangesAsync();

			var test = _context.Companies.ToList();

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

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}
