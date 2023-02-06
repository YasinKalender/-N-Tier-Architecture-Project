using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierArchitecture.Entites.ORM.Concrete;

namespace NTierArchitecture.DAL.EntityConfigurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.Property(i => i.Id).UseIdentityColumn();
            builder.Property(i => i.CategoryName).HasMaxLength(50).IsRequired().HasColumnName("CategoryName");

            builder.HasMany(i => i.Products).WithOne(i => i.Category).HasForeignKey(i => i.CategoryId);
        }
    }
}
