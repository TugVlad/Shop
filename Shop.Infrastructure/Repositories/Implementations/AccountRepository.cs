using Microsoft.EntityFrameworkCore;
using Shop.Application.Repositories.Interfaces;
using Shop.Core.Models;
using Shop.Data;

namespace Shop.Infrastructure.Repositories.Implementations
{
	public class AccountRepository : IAccountRepository
	{
		private readonly ShopContext _context;

		public AccountRepository(ShopContext context)
		{
			_context = context;
		}

		public async Task<Account> AddAccountAsync(Account account)
		{
			await _context.Accounts.AddAsync(account);
			await _context.SaveChangesAsync();

			return account;
		}

		public async Task<List<Account>> GetAllAccountAsync()
		{
			return await _context.Accounts.ToListAsync();
		}
	}
}
