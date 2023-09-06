using Shop.Application.Repositories.Interfaces;
using Shop.Application.Services.DTO;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;

namespace Shop.Application.Services.Implementations
{
	public class LoginService : ILoginService
	{
		private readonly IAccountRepository _accountRepository;
		private readonly ITokenHelper _tokenHelper;
		private readonly IIdentityHelper _identityHelper;

		public LoginService(IAccountRepository accountRepository, ITokenHelper tokenHelper, IIdentityHelper identityHelper)
		{
			_accountRepository = accountRepository;
			_tokenHelper = tokenHelper;
			_identityHelper = identityHelper;
		}

		public async Task<string> GetJWTToken(LoginDTO loginAccount, TokenDetails tokenDetails)
		{
			var identityId = await _identityHelper.ValidateUser(loginAccount.Username, loginAccount.Password);
			var account = await _accountRepository.GetAccountByIdentityIdAsync(identityId);

			if (account == null)
			{
				return null;
			}

			var token = _tokenHelper.GenerateToken(account, tokenDetails);

			return token;
		}
	}
}
