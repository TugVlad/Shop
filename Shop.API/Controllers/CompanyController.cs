using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.API.ViewModels.Company;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;

namespace Shop.API.Controllers
{
	[Route("api/companies")]
	[ApiController]
	public class CompanyController : ControllerBase
	{
		private readonly ICompanyService _companyService;
		private readonly IMapper _mapper;

		public CompanyController(IMapper mapper, ICompanyService companyService)
		{
			_mapper = mapper;
			_companyService = companyService;
		}

		[HttpGet]
		public async Task<ActionResult> GetAllCompanies()
		{
			var companies = await _companyService.GetAllCompaniesAsync();
			return Ok(_mapper.Map<List<CompanyViewModel>>(companies));
		}

		[HttpGet]
		[Route("details")]
		public async Task<ActionResult> GetAllCompaniesWithReviews()
		{
			var companies = await _companyService.GetAllCompaniesWithReviewsAsync();
			return Ok(_mapper.Map<List<CompanyViewModel>>(companies));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetCompanyById(int id)
		{
			var company = await _companyService.GetCompanyByIdAsync(id);
			return company != null ? Ok(_mapper.Map<CompanyViewModel>(company)) : NotFound("Couldn't find the company!");
		}

		[HttpPost]
		public async Task<ActionResult> AddCompany([FromBody] AddCompanyViewModel newCompany)
		{
			var company = await _companyService.AddCompanyAsync(_mapper.Map<Company>(newCompany));
			return company != null ? Ok(_mapper.Map<CompanyViewModel>(company)) : BadRequest("Company could not be added!");
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteCompany(int id)
		{
			var response = await _companyService.DeleteCompanyAsync(id);
			return response ? Ok("Company Deleted!") : NotFound("Couldn't delete the company!");
		}
	}
}
