using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NTierArchitecture.Business.Interfaces;
using NTierArchitecture.DAL.Repositories;
using NTierArchitecture.DTO.DTOs.ProductDtos;
using NTierArchitecture.Entites.ORM.Concrete;
using NTierArchitecture.Web.Filters;

namespace NTierArchitecture.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBaseRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IBaseRepository<Category> categoryRepository, IMapper mapper)
        {
            _productService = productService;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var response = _productService.GetAllProductWithCategory();

            return View(response.Data);
        }

        public IActionResult ProductAdd()
        {
            ViewBag.Category = new SelectList(_categoryRepository.GetAll().ToList(), "Id", "CategoryName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProductAdd(ProductAddDto productAddDto)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(productAddDto);
                await _productService.CreateAsync(product);
                return RedirectToAction("Index");
            }

            ViewBag.Category = new SelectList(_categoryRepository.GetAll().ToList(), "Id", "CategoryName");

            return View(productAddDto);
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        public async Task<IActionResult> ProductUpdate(int Id)
        {
            var product = await _productService.GetByIdAsync(Id);

            var productDto = _mapper.Map<ProductUpdateDto>(product);

            ViewBag.Category = new SelectList(_categoryRepository.GetAll().ToList(), "Id", "CategoryName", productDto.CategoryId);

            return View(productDto);

        }

        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductUpdateDto productUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(productUpdateDto);
                await _productService.UpdateAsync(product);
                return RedirectToAction("Index");
            }

            ViewBag.Category = new SelectList(_categoryRepository.GetAll().ToList(), "Id", "CategoryName", productUpdateDto.CategoryId);

            return View(productUpdateDto);

        }

        public async Task<IActionResult> ProductRemove(int Id)
        {
            var product =await _productService.GetByIdAsync(Id);
            await _productService.DeleteAsync(product);

            return RedirectToAction("Index");
        }

    }
}
