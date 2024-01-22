using Shop.Application.Services.DTO;
using Shop.Core.Models;

namespace Shop.Application.Services.Interfaces
{
	public interface ILoginService
	{
		Task<string> GetJWTToken(LoginDTO loginAccount, TokenDetails tokenDetails);
	}
}
