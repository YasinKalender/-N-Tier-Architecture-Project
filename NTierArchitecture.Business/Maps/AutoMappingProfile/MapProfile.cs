using AutoMapper;
using NTierArchitecture.DTO.DTOs.ProductDtos;
using NTierArchitecture.Entites.ORM.Concrete;

namespace NTierArchitecture.Business.Maps.AutoMappingProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName)).ReverseMap();
            CreateMap<Product, ProductCategoryWithDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName)).ForPath(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName)).ReverseMap();

            CreateMap<Product, ProductAddDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName)).ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName)).ReverseMap();
        }
    }
}
