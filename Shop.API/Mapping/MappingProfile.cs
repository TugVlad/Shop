using AutoMapper;
using Shop.API.ViewModels;
using Shop.Core.Models;

namespace Shop.API.Mapping
{
	public class MappingProfile : Profile
	{
        public MappingProfile()
        {
            CreateMap<Company, CompanyViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
