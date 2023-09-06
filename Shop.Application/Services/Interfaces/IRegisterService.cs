using Shop.Application.Services.DTO;

namespace Shop.Application.Services.Interfaces
{
	public interface IRegisterService
	{
		Task<bool> RegisterUser(RegisterDTO registerDTO);
	}
}
