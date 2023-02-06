using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using NTierArchitecture.Business.Interfaces;
using NTierArchitecture.Business.Maps.AutoMappingProfile;
using NTierArchitecture.Business.Services;
using NTierArchitecture.Business.Validations;
using NTierArchitecture.DAL.Repositories;
using NTierArchitecture.DAL.Uow;

namespace NTierArchitecture.Business.IOC
{
    public static class DependencyResolvers
    {
        public static void DependencyResolver(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            //serviceCollection.AddScoped<IProductService, ProductService>();
            serviceCollection.AddScoped<ICategoryService, CategoryService>();

            serviceCollection.AddMemoryCache();


            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            serviceCollection.AddAutoMapper(typeof(MapProfile));

            //serviceCollection.AddFluentValidation(i => i.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());

        }
    }
}
