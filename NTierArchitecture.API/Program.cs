using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.API.Filter;
using NTierArchitecture.API.Middlewares;
using NTierArchitecture.Business.Interfaces;
using NTierArchitecture.Business.IOC;
using NTierArchitecture.Business.Validations;
using NTierArchitecture.Common.Caching;
using NTierArchitecture.DAL.Context;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt => opt.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(i => i.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());


builder.Services.Configure<ApiBehaviorOptions>(config => config.SuppressModelStateInvalidFilter = true);

builder.Services.AddScoped(typeof(NotFoundFilter<>));

builder.Services.AddScoped<IProductService, ProductServiceCaching>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProjectContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), options =>
{
    options.MigrationsAssembly(Assembly.GetAssembly(typeof(ProjectContext)).GetName().Name);

}));

builder.Services.DependencyResolver();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomExcepiton();

app.UseAuthorization();

app.MapControllers();

app.Run();
