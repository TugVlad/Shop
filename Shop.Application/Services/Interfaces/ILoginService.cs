using Shop.Core.Models;

namespace Shop.Application.Services.Interfaces
{
	public interface ILoginService
	{
		Task<string> GetJWTToken(Account loginAccount, TokenDetails tokenDetails);
	}
}
