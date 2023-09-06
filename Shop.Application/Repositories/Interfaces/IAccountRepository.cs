using Shop.Core.Models;

namespace Shop.Application.Repositories.Interfaces
{
	public interface IAccountRepository : IBaseRepository
	{
		Task<List<Account>> GetAllAccountAsync();
		Task<Account> AddAccountAsync(Account account);
		Task<Account> GetAccountByIdentityIdAsync(string identityId);
	}
}
