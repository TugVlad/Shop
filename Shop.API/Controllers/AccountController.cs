using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.API.ViewModels.Account;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;

namespace Shop.API.Controllers
{
	[Authorize]
	[Route("api/accounts")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IAccountService _accountService;

		public AccountController(IMapper mapper, IAccountService accountService)
		{
			_mapper = mapper;
			_accountService = accountService;
		}

		[HttpGet]
		public async Task<ActionResult> GetAllAccount()
		{
			var currentUserId = User.FindFirst("sub")?.Value;

			var result = await _accountService.GetAccountsAsync();
			return Ok(_mapper.Map<List<AccountViewModel>>(result));
		}

		[Authorize(Policy = "IsAdmin")]
		[HttpPost]
		public async Task<ActionResult> AddAccount([FromBody] CreateAccountViewModel newAccount)
		{
			var account = await _accountService.AddAccountAsync(_mapper.Map<Account>(newAccount));
			return account != null ? Ok(_mapper.Map<AccountViewModel>(account)) : BadRequest("Could not add account!");
		}
	}
}
