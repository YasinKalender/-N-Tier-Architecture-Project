using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierArchitecture.Entites.ORM.Concrete;

namespace NTierArchitecture.DAL.SeedDatas
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product() { Id = 1, ProductName = "Product1", CategoryId = 1, Status = 0, Stock = 100, Price = 1000, CreatedDate = DateTime.Now },
                new Product() { Id = 2, ProductName = "Product2", CategoryId = 1, Status = 0, Stock = 100, Price = 1000, CreatedDate = DateTime.Now },
                new Product() { Id = 3, ProductName = "Product3", CategoryId = 1, Status = 0, Stock = 100, Price = 1000, CreatedDate = DateTime.Now },
                new Product() { Id = 4, ProductName = "Product4", CategoryId = 1, Status = 0, Stock = 100, Price = 1000, CreatedDate = DateTime.Now },
                new Product() { Id = 5, ProductName = "Product5", CategoryId = 2, Status = 0, Stock = 100, Price = 1000, CreatedDate = DateTime.Now },
                new Product() { Id = 6, ProductName = "Product6", CategoryId = 2, Status = 0, Stock = 100, Price = 1000, CreatedDate = DateTime.Now }
                );
        }
    }
}
