using Microsoft.AspNetCore.Mvc;
using Pri.WebApi.Food.Api.Dtos.Categories;
using Pri.WebApi.Food.Api.Dtos.Products;
using Pri.WebApi.Food.Api.Services.Interfaces;

namespace Pri.WebApi.Food.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IProductService _ProductService;
        private readonly ICategoryService _categoryRepository;

        public SearchController(IProductService ProductService,
            ICategoryService categoryRepository)
        {
            _ProductService = ProductService;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string searchQuery)
        {
            var searchResults = await _ProductService.SearchAsync(searchQuery);

            var searchResultsDto = searchResults.Select(s => new ProductResponseDto
            {
                Id = s.Id,
                Name = s.Name,
                Category = new CategoryResponseDto
                {
                    Id = s.Category.Id,
                    Name = s.Category.Name
                }
            });

            return Ok(searchResultsDto);
        }
    }
}
