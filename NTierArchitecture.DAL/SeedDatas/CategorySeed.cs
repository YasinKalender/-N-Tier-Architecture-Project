using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierArchitecture.Entites.ORM.Concrete;

namespace NTierArchitecture.DAL.SeedDatas
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category() { Id = 1, CategoryName = "Category", Status = 0, CreatedDate = DateTime.Now },
                new Category() { Id = 2, CategoryName = "Category2", Status = 0, CreatedDate = DateTime.Now }
                );
        }
    }
}
