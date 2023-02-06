using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierArchitecture.Entites.ORM.Concrete;

namespace NTierArchitecture.DAL.EntityConfigurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();
            builder.Property(i => i.ProductName).HasMaxLength(50).IsRequired().HasColumnName("ProductName");
            builder.Property(i => i.Price).HasColumnType("decimal(18,2)");

            builder.HasOne(i => i.ProductFeature).WithOne(i => i.Product).HasForeignKey<ProductFeature>(c => c.ProductId);

            builder.HasOne(i => i.Category).WithMany(i => i.Products).HasForeignKey(i => i.CategoryId);
        }
    }
}
