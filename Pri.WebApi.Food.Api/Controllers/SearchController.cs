using Microsoft.AspNetCore.Mvc;
using Pri.WebApi.Food.Api.Dtos.Categories;
using Pri.WebApi.Food.Api.Dtos.Products;
using Pri.WebApi.Food.Core.Services.Interfaces;

namespace Pri.WebApi.Food.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IProductService _productService;

        public SearchController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string searchQuery)
        {
            var searchResults = await _productService.SearchAsync(searchQuery);

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
