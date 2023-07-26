using Shop.Application.Repositories.Interfaces;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;

namespace Shop.Application.Services.Implementations
{
	public class LoginService : ILoginService
	{
		private readonly IAccountRepository _accountRepository;
		private readonly ITokenHelper _tokenHelper;

		public LoginService(IAccountRepository accountRepository, ITokenHelper tokenHelper)
		{
			_accountRepository = accountRepository;
			_tokenHelper = tokenHelper;
		}

		public async Task<string> GetJWTToken(Account loginAccount, TokenDetails tokenDetails)
		{
			var account = await _accountRepository.GetAccountByCredentialsAsync(loginAccount.Email, loginAccount.Password);

			if (account == null)
			{
				return null;
			}

			var token = _tokenHelper.GenerateToken(account, tokenDetails);

			return token;
		}
	}
}
