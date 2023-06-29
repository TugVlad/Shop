using Shop.Application.Repositories.Interfaces;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;

namespace Shop.Application.Services.Implementations
{
	public class AccountService : IAccountService
	{
		private readonly IAccountRepository _accountRepository;

		public AccountService(IAccountRepository accountRepository)
		{
			_accountRepository = accountRepository;
		}

		public async Task<Account> AddAccountAsync(Account account)
		{
			return await _accountRepository.AddAccountAsync(account);
		}

		public async Task<List<Account>> GetAccountsAsync()
		{
			return await _accountRepository.GetAllAccountAsync();
		}
	}
}
