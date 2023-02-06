using NTierArchitecture.DTO.DTOs.ProductDtos;

namespace NTierArchitecture.DTO.DTOs.CategoryDtos
{
    public class CategoryWithProducts
    {
        public string CategoryName { get; set; }
        public List<ProductDto> Product { get; set; }
    }
}
