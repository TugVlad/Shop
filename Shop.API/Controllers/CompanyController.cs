using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Services;
using Shop.API.ViewModels.Company;
using Shop.API.ViewModels.HATEOAS;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;

namespace Shop.API.Controllers
{
	[Authorize(AuthenticationSchemes = "Bearer")]
	[Route("api/companies")]
	[ApiController]
	public class CompanyController : ControllerBase
	{
		private readonly ICompanyService _companyService;
		private readonly IMapper _mapper;
		private readonly IHATEOASService _hateoasService;

		public CompanyController(IMapper mapper, ICompanyService companyService, IHATEOASService hateoasService)
		{
			_mapper = mapper;
			_companyService = companyService;
			_hateoasService = hateoasService;
		}

		[AllowAnonymous]
		[HttpGet(Name = "GetAllCompanies")]
		public async Task<ActionResult> GetAllCompanies()
		{
			var companies = await _companyService.GetAllCompaniesAsync();

			var mappedResult = _mapper.Map<List<CompanyViewModel>>(companies);
			var hateoasResult = new HATEOASExtension<List<CompanyViewModel>>(mappedResult);
			hateoasResult.Links = _hateoasService.GetCompanyLinks(0);

			return Ok(hateoasResult);
		}

		[HttpGet]
		[Route("details", Name = "GetAllCompaniesDetails")]
		public async Task<ActionResult> GetAllCompaniesWithReviews()
		{
			var companies = await _companyService.GetAllCompaniesWithReviewsAsync();

			var mappedResult = _mapper.Map<List<CompanyViewModel>>(companies);
			var hateoasResult = new HATEOASExtension<List<CompanyViewModel>>(mappedResult);
			hateoasResult.Links = _hateoasService.GetCompanyLinks(0);

			return Ok(hateoasResult);
		}

		[AllowAnonymous]
		[HttpGet("{id}", Name = "GetCompanyById")]
		public async Task<ActionResult> GetCompanyById(int id)
		{
			var company = await _companyService.GetCompanyByIdAsync(id);

			if (company == null)
			{
				return NotFound("Couldn't find the company!");
			}

			var mappedResult = _mapper.Map<CompanyViewModel>(company);
			var hateoasResult = new HATEOASExtension<CompanyViewModel>(mappedResult);
			hateoasResult.Links = _hateoasService.GetLinks(new List<LinkDetails>()
			{
				new LinkDetails("GetAllCompanies","GET"),
				new LinkDetails("GetAllCompaniesDetails","GET"),
				new LinkDetails("GetCompanyById","SELF",id),
				new LinkDetails("AddCompany","POST"),
				new LinkDetails("DeleteCompany","DELETE",id),
				new LinkDetails("AddCompanyReview","POST"),

			});

			return Ok(hateoasResult);
		}

		[Authorize(Policy = "IsAdmin")]
		[HttpPost(Name = "AddCompany")]
		public async Task<ActionResult> AddCompany([FromBody] AddCompanyViewModel newCompany)
		{
			var company = await _companyService.AddCompanyAsync(_mapper.Map<Company>(newCompany));

			if (company == null)
			{
				return BadRequest("Company could not be added!");
			}

			var mappedResult = _mapper.Map<CompanyViewModel>(company);
			var hateoasResult = new HATEOASExtension<CompanyViewModel>(mappedResult);
			hateoasResult.Links = _hateoasService.GetCompanyLinks(0);

			return Ok(hateoasResult);
		}

		[Authorize(Policy = "IsAdmin")]
		[HttpDelete("{id}", Name = "DeleteCompany")]
		public async Task<ActionResult> DeleteCompany(int id)
		{
			var response = await _companyService.DeleteCompanyAsync(id);

			if (!response)
			{
				return NotFound("Couldn't delete the company!");
			}

			var hateoasResult = new HATEOASExtension<string>("Company Deleted!");
			hateoasResult.Links = _hateoasService.GetCompanyLinks(id);

			return Ok(hateoasResult);
		}
	}
}
