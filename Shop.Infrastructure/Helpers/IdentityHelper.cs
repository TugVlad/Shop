using Microsoft.AspNetCore.Identity;
using Shop.Application.Repositories.Interfaces;
using Shop.Application.Services.DTO;

namespace Shop.Infrastructure.Helpers
{
	public class IdentityHelper : IIdentityHelper
	{
		private UserManager<IdentityUser> _userManager;

		public IdentityHelper(UserManager<IdentityUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<string> ValidateUser(string userName, string password)
		{
			var identityUser = await _userManager.FindByNameAsync(userName);

			if (identityUser == null)
			{
				return null;
			}

			var isUserValid = await _userManager.CheckPasswordAsync(identityUser, password);

			if (!isUserValid)
			{
				return null;
			}

			return identityUser.Id;
		}

		public async Task<string> RegisterUser(RegisterDTO registerDTO)
		{
			var identityUser = new IdentityUser { Email = registerDTO.Email, UserName = registerDTO.Username };
			var identityUserResult = await _userManager.CreateAsync(identityUser, registerDTO.Password);

			if (!identityUserResult.Succeeded)
			{
				throw new Exception("Failed to create identity user");
			}

			return identityUser.Id;
		}
	}
}
