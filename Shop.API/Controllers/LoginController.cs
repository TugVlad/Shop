using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.API.ViewModels.Login;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;

namespace Shop.API.Controllers
{
	[Route("api/login")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly IMapper _mapper;
		private readonly ILoginService _loginService;

		public LoginController(IConfiguration configuration, IMapper mapper, ILoginService loginService)
		{
			_configuration = configuration;
			_mapper = mapper;
			_loginService = loginService;
		}

		[HttpPost(Name = "Login")]
		public async Task<ActionResult> GenerateToken([FromBody] LoginViewModel loginViewModel)
		{
			var tokenDetails = new TokenDetails(
				_configuration.GetValue<string>("SigningKey"),
				_configuration.GetValue<string>("Issuer"),
				_configuration.GetValue<string>("Audience"));

			var token = await _loginService.GetJWTToken(_mapper.Map<Account>(loginViewModel), tokenDetails);

			return token != null ? Ok(token) : BadRequest("Invalid credentials!");
		}
	}
}
