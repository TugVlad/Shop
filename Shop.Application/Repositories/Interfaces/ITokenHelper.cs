using Shop.Core.Models;

namespace Shop.Application.Repositories.Interfaces
{
	public interface ITokenHelper
	{
		string GenerateToken(Account account, TokenDetails tokenDetails);
	}
}
