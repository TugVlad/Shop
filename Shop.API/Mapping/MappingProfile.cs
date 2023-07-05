using AutoMapper;
using Shop.API.ViewModels.Account;
using Shop.API.ViewModels.Company;
using Shop.API.ViewModels.Order;
using Shop.API.ViewModels.Product;
using Shop.Core.Models;

namespace Shop.API.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Company, AddCompanyViewModel>().ReverseMap();
			CreateMap<Company, CompanyViewModel>().ReverseMap();

			CreateMap<Product, AddProductViewModel>().ReverseMap();
			CreateMap<ProductInCart, ProductInCartViewModel>().ReverseMap();
			CreateMap<Product, ProductViewModel>().ReverseMap();

			CreateMap<Account, CreateAccountViewModel>().ReverseMap();
			CreateMap<Account, AccountViewModel>().ReverseMap();

			CreateMap<Order, AddOrderViewModel>().ReverseMap();
			CreateMap<Order, OrderViewModel>().ReverseMap();
			CreateMap<ProductOrder, ProductOrderViewModel>().ReverseMap();

			CreateMap<Review, CompanyReviewViewModel>().ReverseMap();
			CreateMap<Review, AddCompanyReviewViewModel>().ReverseMap();
			CreateMap<Review, ProductReviewViewModel>().ReverseMap();
			CreateMap<Review, AddProductReviewViewModel>().ReverseMap();
		}
	}
}
