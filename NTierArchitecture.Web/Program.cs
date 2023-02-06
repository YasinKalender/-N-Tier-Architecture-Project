using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Business.Interfaces;
using NTierArchitecture.Business.IOC;
using NTierArchitecture.Business.Services;
using NTierArchitecture.Business.Validations;
using NTierArchitecture.DAL.Context;
using NTierArchitecture.DTO.DTOs.ProductDtos;
using NTierArchitecture.Web.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation();

builder.Services.AddScoped<IValidator<ProductAddDto>, ProductAddDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ProductAddDtoValidator>();


builder.Services.AddDbContext<ProjectContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), config =>
{
    config.MigrationsAssembly(Assembly.GetAssembly(typeof(ProjectContext)).GetName().Name);

}));

builder.Services.AddScoped(typeof(NotFoundFilter<>));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddMemoryCache();

builder.Services.DependencyResolver();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
