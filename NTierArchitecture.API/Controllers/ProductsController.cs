using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.API.Filter;
using NTierArchitecture.Business.Interfaces;
using NTierArchitecture.DTO.DTOs;
using NTierArchitecture.DTO.DTOs.CategoryDtos;
using NTierArchitecture.DTO.DTOs.ProductDtos;
using NTierArchitecture.Entites.ORM.Concrete;

namespace NTierArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateFilterAttribute]
    public class ProductsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IMapper mapper, IProductService productService, ICategoryService categoryService)
        {
            _mapper = mapper;
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var result = _mapper.Map<List<ProductDto>>(_productService.GetAll().ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(StatusCodes.Status200OK,result));
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        public async Task<IActionResult> GetById(int id)
        {
            var result = _mapper.Map<ProductDto>(await _productService.GetByIdAsync(id));
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(StatusCodes.Status200OK, result));
        }

        [HttpPost]
        [ValidateFilterAttribute]
        public async Task<IActionResult> Save(ProductDto product)
        {
            var result = await _productService.CreateAsync(_mapper.Map<Product>(product));
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(StatusCodes.Status201Created));
        }
        [HttpGet("[action]")]
        public IActionResult ProductWithCategory()
        {
            var result = _productService.GetAllProductWithCategory();
            return CreateActionResult(result);
        }

        [HttpGet("CategoryWithProduct")]
        public IActionResult CategoryWithProduct()
        {
            var result = _categoryService.CategoryWithProducts();
            return CreateActionResult(CustomResponseDto<List<CategoryWithProducts>>.Success(StatusCodes.Status200OK, result));
        }

    }
}
