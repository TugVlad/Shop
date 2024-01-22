using Shop.Application.Services.DTO;

namespace Shop.Application.Repositories.Interfaces
{
	public interface IIdentityHelper
	{
		Task<string> RegisterUser(RegisterDTO registerDTO);
		Task<string> ValidateUser(string userName, string password);
	}
}
