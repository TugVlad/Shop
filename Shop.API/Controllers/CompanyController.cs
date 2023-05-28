using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.API.ViewModels;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;

namespace Shop.API.Controllers
{
	[Route("api/[controller]")]
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
			return Ok(companies);
		}

		[HttpGet]
		[Route("companyWithReviews")]
		public async Task<ActionResult> GetAllCompaniesWithReviews()
		{
			var companies = await _companyService.GetAllCompaniesWithReviewsAsync();
			return Ok(companies);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetCompanyById(int id)
		{
			var company = await _companyService.GetCompanyByIdAsync(id);
			return company != null ? Ok(company) : NotFound();
		}

		[HttpPost]
		public async Task<ActionResult> AddCompany([FromBody] CompanyViewModel newCompany)
		{
			var company = await _companyService.AddCompanyAsync(_mapper.Map<Company>(newCompany));
			return Ok(company);
		}

		[HttpPost]
		[Route("addReview")]
		public async Task<ActionResult> AddCompanyReview([FromBody] CompanyReviewViewModel request)
		{
			var product = await _companyService.AddCompanyReviewAsync(request.CompanyId, request.ReviewMessage);
			return Ok(product);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteCompany(int id)
		{
			var response = await _companyService.DeleteCompanyAsync(id);
			return response ? Ok("Company Deleted!") : NotFound();
		}
	}
}
