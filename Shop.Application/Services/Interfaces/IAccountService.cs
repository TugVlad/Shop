using Shop.Core.Models;

namespace Shop.Application.Services.Interfaces
{
	public interface IAccountService
	{
		Task<List<Account>> GetAccountsAsync();
		Task<Account> AddAccountAsync(Account account);
	}
}
