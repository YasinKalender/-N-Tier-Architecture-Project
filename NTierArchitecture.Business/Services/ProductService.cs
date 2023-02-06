using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.Business.Interfaces;
using NTierArchitecture.DAL.Repositories;
using NTierArchitecture.DAL.Uow;
using NTierArchitecture.DTO.DTOs;
using NTierArchitecture.DTO.DTOs.ProductDtos;
using NTierArchitecture.Entites.ORM.Concrete;

namespace NTierArchitecture.Business.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private IBaseRepository<Product> _productRepository
        {
            get
            {
                return _unitOfWork.GetBaseRepository<Product>();
            }
        }

        public CustomResponseDto<List<ProductCategoryWithDto>> GetAllProductWithCategory()
        {
            var query = _productRepository.GetAll().Include(i => i.Category);

            var data = _mapper.Map<List<ProductCategoryWithDto>>(query);

            var list = query.Select(i => new ProductCategoryWithDto()
            {
                Id=i.Id,
                CategoryName = i.Category.CategoryName,
                Name = i.ProductName,
                Price = i.Price,
                CreatedDate = i.CreatedDate,
                Stock = i.Stock

            }).ToList();

            return CustomResponseDto<List<ProductCategoryWithDto>>.Success(StatusCodes.Status200OK, list);

        }
    }
}
