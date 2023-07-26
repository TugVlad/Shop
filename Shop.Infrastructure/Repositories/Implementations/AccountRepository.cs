using Microsoft.EntityFrameworkCore;
using Shop.Application.Repositories.Interfaces;
using Shop.Core.Models;
using Shop.Data;

namespace Shop.Infrastructure.Repositories.Implementations
{
	public class AccountRepository : BaseRepository, IAccountRepository
	{
		public AccountRepository(ShopContext context) : base(context) { }

		public async Task<Account> AddAccountAsync(Account account)
		{
			await _context.Accounts.AddAsync(account);
			return account;
		}

		public async Task<List<Account>> GetAllAccountAsync()
		{
			return await _context.Accounts.ToListAsync();
		}

		public async Task<Account> GetAccountByCredentialsAsync(string email, string password)
		{
			return await _context.Accounts.FirstOrDefaultAsync(e => e.Email == email && e.Password == password);
		}
	}
}
