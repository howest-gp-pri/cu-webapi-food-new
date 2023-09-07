using Pri.WebApi.Food.Core.Entities;

namespace Pri.WebApi.Food.Core.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetByCategoryIdAsync(Guid id);
        Task<IEnumerable<Product>> SearchAsync(string search);
    }
}
