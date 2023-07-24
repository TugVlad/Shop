using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.API.ViewModels.Company;
using Shop.API.ViewModels.Product;
using Shop.Application.Services.Interfaces;
using Shop.Core.Models;

namespace Shop.API.Controllers
{
	[Authorize]
	[Route("api/reviews")]
	[ApiController]
	public class ReviewController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IProductService _productService;
		private readonly ICompanyService _companyService;

		public ReviewController(IMapper mapper, IProductService productService, ICompanyService companyService)
		{
			_mapper = mapper;
			_productService = productService;
			_companyService = companyService;
		}

		[HttpPost]
		[Route("product")]
		public async Task<ActionResult> AddProductReview([FromBody] AddProductReviewViewModel review)
		{
			var product = await _productService.AddProductReviewAsync(_mapper.Map<Review>(review));
			return product != null ? Ok(_mapper.Map<ProductViewModel>(product)) : BadRequest("Could not add product review!");
		}

		[HttpPost]
		[Route("company")]
		public async Task<ActionResult> AddCompanyReview([FromBody] AddCompanyReviewViewModel review)
		{
			var company = await _companyService.AddCompanyReviewAsync(_mapper.Map<Review>(review));
			return company != null ? Ok(_mapper.Map<CompanyViewModel>(company)) : BadRequest("Could not add company review!");
		}
	}
}
