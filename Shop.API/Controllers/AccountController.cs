using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.API.ViewModels;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;

namespace Shop.API.Controllers
{
	[Route("api/[controller]")]
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
			var result = await _accountService.GetAccountsAsync();
			return Ok(_mapper.Map<List<AccountViewModel>>(result));
		}

		[HttpPost]
		public async Task<ActionResult> AddAccount([FromBody] CreateAccountViewModel newAccount)
		{
			var account = await _accountService.AddAccountAsync(_mapper.Map<Account>(newAccount));
			return Ok(_mapper.Map<AccountViewModel>(account));
		}
	}
}
