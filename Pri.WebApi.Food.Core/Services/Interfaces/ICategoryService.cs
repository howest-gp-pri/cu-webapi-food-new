using Pri.WebApi.Food.Core.Entities;

namespace Pri.WebApi.Food.Core.Services.Interfaces
{
    public interface ICategoryService
    {
        IQueryable<Category> GetAll();
        Task<IEnumerable<Category>> ListAllAsync();
        Task<Category> GetByIdAsync(Guid id);
        Task<Category> UpdateAsync(Category entity);
        Task<Category> AddAsync(Category entity);
        Task<Category> DeleteAsync(Category entity);
    }
}
