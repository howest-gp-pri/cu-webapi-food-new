using Microsoft.AspNetCore.Mvc;
using Pri.WebApi.Food.Api.Dtos.Categories;
using Pri.WebApi.Food.Api.Dtos.Products;
using Pri.WebApi.Food.Api.Entities;
using Pri.WebApi.Food.Api.Services.Interfaces;

namespace Pri.WebApi.Food.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        protected readonly ICategoryService _categoryService;
        protected readonly IProductService _productService;

        public CategoriesController(
            ICategoryService categoryService, 
            IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.ListAllAsync();
            var categoriesDto = categories.Select(c => new CategoryResponseDto
            {
                Id = c.Id,
                Name = c.Name
            });

            return Ok(categoriesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound($"No category with an id of {id}");
            }
            var categoryDto = new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name
            };

            return Ok(categoryDto);
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetProductsFromCategory(Guid id)
        {
            var products = await _productService.GetByCategoryIdAsync(id);

            var productsDto = products.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Category = new CategoryResponseDto
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name
                }
            });

            return Ok(productsDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryRequestDto categoryDto)
        {
            var categoryEntity = new Category
            {
                Name = categoryDto.Name
            };

            await _categoryService.AddAsync(categoryEntity);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryRequestDto categoryDto)
        {
            var categoryEntity = await _categoryService.GetByIdAsync(categoryDto.Id);

            if (categoryEntity == null)
            {
                return NotFound($"No category with an id of {categoryDto.Id}");
            }

            categoryEntity.Name = categoryDto.Name;

            await _categoryService.UpdateAsync(categoryEntity);

            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var categoryEntity = await _categoryService.GetByIdAsync(id);

            if (categoryEntity == null)
            {
                return NotFound($"No category with an id of {id}");
            }

            await _categoryService.DeleteAsync(categoryEntity);

            return Ok();
        }
    }
}
