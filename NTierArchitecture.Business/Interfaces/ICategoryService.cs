using NTierArchitecture.DTO.DTOs.CategoryDtos;
using NTierArchitecture.Entites.ORM.Concrete;

namespace NTierArchitecture.Business.Interfaces
{
    public interface ICategoryService : IBaseService<Category>
    {
        List<CategoryWithProducts> CategoryWithProducts();
    }
}
