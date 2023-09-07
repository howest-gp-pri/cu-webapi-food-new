using Pri.WebApi.Food.Core.Entities;

namespace Pri.WebApi.Food.Core.Services.Interfaces
{
    public interface IProductService
    {
        IQueryable<Product> GetAll();
        Task<IEnumerable<Product>> ListAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task<Product> UpdateAsync(Product entity);
        Task<Product> AddAsync(Product entity);
        Task<Product> DeleteAsync(Product entity);

        Task<IEnumerable<Product>> GetByCategoryIdAsync(Guid id);
        Task<IEnumerable<Product>> SearchAsync(string search);
    }
}
