using Shop.Core.Models;

namespace Shop.Application.Repositories.Interfaces
{
	public interface IAccountRepository
	{
		Task<List<Account>> GetAllAccountAsync();
		Task<Account> AddAccountAsync(Account account);
	}
}
