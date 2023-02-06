using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using NTierArchitecture.Business.Interfaces;
using NTierArchitecture.DAL.Uow;
using NTierArchitecture.DTO.DTOs;
using NTierArchitecture.DTO.DTOs.ProductDtos;
using NTierArchitecture.Entites.ORM.Concrete;
using System.Linq.Expressions;

namespace NTierArchitecture.Common.Caching
{
    public class ProductServiceCaching : IProductService
    {
        private const string productListCacheKey = "productList";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IUnitOfWork _unitOfWork;

        public ProductServiceCaching(IMemoryCache memoryCache, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _memoryCache = memoryCache;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

            if (!_memoryCache.TryGetValue(productListCacheKey, out object list))
            {
                _memoryCache.Set(productListCacheKey, _unitOfWork.GetBaseRepository<Product>().GetAll().ToList());
            }
        }

        public async Task AddRangeAsync(IEnumerable<Product> entities)
        {
            await _unitOfWork.GetBaseRepository<Product>().AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            CacheAllProduct();
        }

        public Task<Product> CreateAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> FindAsync(Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetAll()
        {
            if (!_memoryCache.TryGetValue(productListCacheKey, out object list))
            {
                _memoryCache.Set(productListCacheKey, _unitOfWork.GetBaseRepository<Product>().GetAll().ToList());
            }

            return _memoryCache.Get<List<Product>>(productListCacheKey).AsQueryable();
        }

        public IQueryable<Product> GetAll(Expression<Func<Product, bool>> expression)
        {
            if (!_memoryCache.TryGetValue(productListCacheKey, out object list))
            {
                _memoryCache.Set(productListCacheKey, _unitOfWork.GetBaseRepository<Product>().GetAll(expression).ToList());
            }

            return _memoryCache.Get<List<Product>>(productListCacheKey).Where(expression.Compile()).AsQueryable();
        }

        public CustomResponseDto<List<ProductCategoryWithDto>> GetAllProductWithCategory()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> CacheAllProduct()
        {
            return _memoryCache.Set(productListCacheKey, _unitOfWork.GetBaseRepository<Product>().GetAll().AsQueryable());

        }
    }
}
