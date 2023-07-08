using Shop.Application.Repositories.Interfaces;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;

namespace Shop.Application.Services.Implementations
{
	public class AccountService : BaseService, IAccountService
	{
		private readonly IAccountRepository _accountRepository;

		public AccountService(IAccountRepository accountRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
		{
			_accountRepository = accountRepository;
		}

		public async Task<Account> AddAccountAsync(Account newAccount)
		{
			try
			{
				var account = await _accountRepository.AddAccountAsync(newAccount);
				await _unitOfWork.SaveChangesAsync();

				return account;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public async Task<List<Account>> GetAccountsAsync()
		{
			return await _accountRepository.GetAllAccountAsync();
		}
	}
}
