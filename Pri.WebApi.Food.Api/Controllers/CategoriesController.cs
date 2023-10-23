using Microsoft.AspNetCore.Mvc;
using Pri.WebApi.Food.Api.Dtos.Categories;
using Pri.WebApi.Food.Api.Dtos.Products;
using Pri.WebApi.Food.Core.Entities;
using Pri.WebApi.Food.Core.Services.Interfaces;

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

            var categoryDtos = categories.Select(c => new CategoryResponseDto
            {
                Id = c.Id,
                Name = c.Name
            });

            return Ok(categoryDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound($"No category found with {id}");
            }

            var categoryDto = new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name
            };

            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryRequestDto categoryDto)
        {
            var existsCategory = await _categoryService.GetByName(categoryDto.Name);

            if (existsCategory is not null)
            {
                return BadRequest($"A product with the name '{categoryDto.Name}' already exists.");
            }

            Category category = new Category
            {
                Name = categoryDto.Name
            };

            try
            {
                await _categoryService.AddAsync(category);
            }
            catch
            {
                return StatusCode(500);
            }

            var dto = new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name
            };

            return CreatedAtAction(nameof(Get), new { id = category.Id }, dto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryRequestDto categoryDto)
        {
            var existingCategory = await _categoryService.GetByIdAsync(categoryDto.Id);

            if (existingCategory == null)
            {
                return BadRequest($"No category with id '{categoryDto.Id}' found");
            }

            existingCategory.Name = categoryDto.Name;

            var checkUniqueName = await _categoryService.CheckIfUpdateCategoryIsUnique(existingCategory);

            if (!checkUniqueName.Success) 
            {
                foreach(var error in checkUniqueName.Errors)
                {
                    ModelState.AddModelError(nameof(categoryDto.Name), error);
                }
                return BadRequest(ModelState);
            }

            else
            {
                await _categoryService.UpdateAsync(existingCategory);

                var dto = new CategoryResponseDto
                {
                    Id = existingCategory.Id,
                    Name = existingCategory.Name
                };

                return Ok(dto);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existingCategory = await _categoryService.GetByIdAsync(id);

            if (existingCategory == null)
            {
                return NotFound($"No category with an id of {id}");
            }

            var canDeleteResult = await _categoryService.CheckIfCategoryCanBeDeleted(existingCategory);

            if (canDeleteResult.Errors.Any())
            {
                foreach (var error in canDeleteResult.Errors)
                {
                    ModelState.AddModelError(nameof(id), error);
                }
                return BadRequest(ModelState);
            }

            await _categoryService.DeleteAsync(existingCategory);

            return Ok();
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
    }
}
