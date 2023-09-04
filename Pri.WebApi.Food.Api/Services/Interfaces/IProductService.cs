using Pri.WebApi.Food.Api.Entities;

namespace Pri.WebApi.Food.Api.Services.Interfaces
{
    public interface IProductService : IBaseService<Product>
    {
        Task<IEnumerable<Product>> GetByCategoryIdAsync(Guid id);
        Task<IEnumerable<Product>> SearchAsync(string search);
    }
}
