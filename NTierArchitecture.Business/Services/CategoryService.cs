using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Business.Interfaces;
using NTierArchitecture.DAL.Repositories;
using NTierArchitecture.DAL.Uow;
using NTierArchitecture.DTO.DTOs.CategoryDtos;
using NTierArchitecture.Entites.ORM.Concrete;

namespace NTierArchitecture.Business.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        private IBaseRepository<Category> _categoryRepository
        {
            get
            {
                return _unitOfWork.GetBaseRepository<Category>();
            }
        }

        public List<CategoryWithProducts> CategoryWithProducts()
        {
            var query = _categoryRepository.GetAll();
            var list = query.Select(i => new CategoryWithProducts()
            {
                CategoryName = i.CategoryName,
                Product = i.Products.Select(k => new DTO.DTOs.ProductDtos.ProductDto()
                {
                    Name = k.ProductName,
                    Price = k.Price,
                    CreatedDate = k.CreatedDate,
                    Stock = k.Stock

                }).ToList()


            }).ToList();

            return list;
        }
    }
}
