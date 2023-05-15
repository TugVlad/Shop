using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Services.Implementations;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;
using Shop.Core.ViewModels;

namespace Shop.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompanyController : ControllerBase
	{
		private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

		[HttpGet]
		public async Task<ActionResult> GetAllCompanies()
		{
			var companies = await companyService.GetAllCompaniesAsync();
			return Ok(companies);
		}

		[HttpGet]
		[Route("companyWithReviews")]
		public async Task<ActionResult> GetAllCompaniesWithReviews()
		{
			var companies = await companyService.GetAllCompaniesWithReviewsAsync();
			return Ok(companies);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetCompanyById(int id)
		{
			var company = await companyService.GetCompanyByIdAsync(id);
			return company != null ? Ok(company) : NotFound();
		}

		[HttpPost]
		public async Task<ActionResult> AddCompany([FromBody] CompanyViewModel newCompany)
		{
			var company = await companyService.AddCompanyAsync(newCompany);
			return Ok(company);
		}

		[HttpPost]
		[Route("addReview")]
		public async Task<ActionResult> AddCompanyReview([FromBody] CompanyReviewViewModel request)
		{
			var product = await companyService.AddCompanyReviewAsync(request.CompanyId, request.ReviewMessage);
			return Ok(product);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteCompany(int id)
		{
			var response = await companyService.DeleteCompanyAsync(id);
			return response ? Ok("Company Deleted!") : NotFound();
		}
	}
}
