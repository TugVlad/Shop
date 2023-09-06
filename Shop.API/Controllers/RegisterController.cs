using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.API.ViewModels.Register;
using Shop.Application.Services.DTO;
using Shop.Application.Services.Interfaces;

namespace Shop.API.Controllers
{
	[Route("api/register")]
	[ApiController]
	public class RegisterController : ControllerBase
	{
		private readonly IRegisterService _registerService;
		private readonly IMapper _mapper;

		public RegisterController(IRegisterService registerService, IMapper mapper)
		{
			_registerService = registerService;
			_mapper = mapper;
		}

		[HttpPost(Name = "Register")]
		public async Task<ActionResult> Register([FromBody] RegisterViewModel registerViewModel)
		{
			var response = await _registerService.RegisterUser(_mapper.Map<RegisterDTO>(registerViewModel));
			return Ok(response);
		}

	}
}
