using NTierArchitecture.DTO.DTOs;
using NTierArchitecture.DTO.DTOs.ProductDtos;
using NTierArchitecture.Entites.ORM.Concrete;

namespace NTierArchitecture.Business.Interfaces
{
    public interface IProductService : IBaseService<Product>
    {
        CustomResponseDto<List<ProductCategoryWithDto>> GetAllProductWithCategory();
    }
}
