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
			await _unitOfWork.BeginTransaction();
			try
			{
				var account = await _accountRepository.AddAccountAsync(newAccount);

				await _unitOfWork.CommitTransaction();
				return account;
			}
			catch (Exception)
			{
				await _unitOfWork.RollbackTransaction();
			}

			return null;
		}

		public async Task<List<Account>> GetAccountsAsync()
		{
			return await _accountRepository.GetAllAccountAsync();
		}
	}
}
