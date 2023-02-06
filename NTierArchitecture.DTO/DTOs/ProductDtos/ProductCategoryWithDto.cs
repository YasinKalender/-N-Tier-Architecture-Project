namespace NTierArchitecture.DTO.DTOs.ProductDtos
{
    public class ProductCategoryWithDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CategoryName { get; set; }
    }
}
