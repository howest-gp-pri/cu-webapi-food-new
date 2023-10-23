using Microsoft.AspNetCore.Mvc;
using Pri.WebApi.Food.Api.Dtos.Categories;
using Pri.WebApi.Food.Api.Dtos.Products;
using Pri.WebApi.Food.Core.Entities;
using Pri.WebApi.Food.Core.Services.Interfaces;

namespace Pri.WebApi.Food.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        protected readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(
            IProductService productService,
            ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.ListAllAsync();
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound($"No product with an id of {id}");
            }

            var productDto = new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = new CategoryResponseDto
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name
                }
            };

            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductRequestDto productDto)
        {
            // Check if CategoryId exists in db
            var category = await _categoryService.GetByIdAsync(productDto.CategoryId);

            if (category == null)
            {
                return BadRequest($"Cannot add new product because category with id {productDto.CategoryId} does not exists");
            }

            var product = new Product
            {
                CategoryId = productDto.CategoryId,
                Name = productDto.Name
            };

            //In our db, it is allowed to have products with the same name
            await _productService.AddAsync(product);

            var dto = new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = new CategoryResponseDto
                {
                    Id = category.Id,
                    Name = category.Name
                }
            };

            return CreatedAtAction(nameof(Get), new { id = product.Id }, dto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductRequestDto productDto)
        {
            // Check if CategoryId exists in db
            var category = await _categoryService.GetByIdAsync(productDto.CategoryId);

            if (category == null)
            {
                return BadRequest($"Cannot update product because category with id {productDto.CategoryId} does not exists");
            }

            var product = await _productService.GetByIdAsync(productDto.Id);

            if (product == null)
            {
                return BadRequest($"No product with an id of {productDto.Id}");
            }

            product.CategoryId = productDto.CategoryId;
            product.Name = productDto.Name;

            //In our db, it is allowed to have products with the same name
            await _productService.UpdateAsync(product);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound($"No product with an id of {id}");
            }

            await _productService.DeleteAsync(product);

            return Ok();
        }
    }
}
