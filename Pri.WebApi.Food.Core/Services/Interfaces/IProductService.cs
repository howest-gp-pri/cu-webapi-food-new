using Pri.WebApi.Food.Core.Entities;

namespace Pri.WebApi.Food.Core.Services.Interfaces
{
    public interface IProductService
    {
        IQueryable<Product> GetAll();
        Task<IEnumerable<Product>> ListAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task UpdateAsync(Product entity);
        Task AddAsync(Product entity);
        Task DeleteAsync(Product entity);

        Task<IEnumerable<Product>> GetByCategoryIdAsync(Guid id);
        Task<IEnumerable<Product>> SearchAsync(string search);
    }
}
