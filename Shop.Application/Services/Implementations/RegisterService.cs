using Shop.Application.Repositories.Interfaces;
using Shop.Application.Services.DTO;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;

namespace Shop.Application.Services.Implementations
{
	public class RegisterService : BaseService, IRegisterService
	{
		private readonly IAccountRepository _accountRepository;
		private readonly IIdentityHelper _identityHelper;

		public RegisterService(IAccountRepository accountRepository, IIdentityHelper identityHelper, IUnitOfWork unitOfWork) : base(unitOfWork)
		{
			_accountRepository = accountRepository;
			_identityHelper = identityHelper;
		}

		public async Task<bool> RegisterUser(RegisterDTO registerDTO)
		{
			await _unitOfWork.BeginTransactionAsync();
			try
			{
				var accountCheck = false;
				var identityId = await _identityHelper.RegisterUser(registerDTO);
				if (identityId != null)
				{
					accountCheck = (await _accountRepository.AddAccountAsync(new Account(registerDTO.Username, identityId, registerDTO.Email, "", ""))) != null;
				}

				await _unitOfWork.SaveChangesAsync();
				await _unitOfWork.CommitTransactionAsync();

				return accountCheck;
			}
			catch (Exception)
			{
				await _unitOfWork.RollbackTransactionAsync();
				return false;
			}
		}
	}
}
