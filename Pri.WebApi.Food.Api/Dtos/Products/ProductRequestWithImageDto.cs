using System.ComponentModel.DataAnnotations;

namespace Pri.WebApi.Food.Api.Dtos.Products
{
    public class ProductRequestWithImageDto : ProductRequestDto
    {
        public IFormFile Image { get; set; }
        [FileExtensions(Extensions = "jpg,png")]
        public string Filename => Image?.FileName;
    }
}
