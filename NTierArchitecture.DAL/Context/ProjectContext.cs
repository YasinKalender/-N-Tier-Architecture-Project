using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Entites.ORM.Concrete;
using System.Reflection;

namespace NTierArchitecture.DAL.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductFeature> ProductFeature { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>().HasKey(i => i.Id);
        //    modelBuilder.Entity<Product>().Property(i => i.ProductName).HasColumnName("ProductName");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate = DateTime.UtcNow;
                                entityReference.Status = Entites.ORM.Enums.Status.Active;
                                break;
                            }

                        case EntityState.Modified:
                            {
                                Entry(entityReference).Property(i => i.CreatedDate).IsModified = false;
                                entityReference.UpdateDate = DateTime.UtcNow;
                                entityReference.Status = Entites.ORM.Enums.Status.Updated;
                                break;
                            }
                        default:
                            break;
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
