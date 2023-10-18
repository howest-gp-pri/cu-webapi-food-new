using Pri.WebApi.Food.Core.Entities;
using Pri.WebApi.Food.Core.Services.Models;

namespace Pri.WebApi.Food.Core.Services.Interfaces
{
    public interface ICategoryService
    {
        IQueryable<Category> GetAll();
        Task<IEnumerable<Category>> ListAllAsync();
        Task<Category> GetByIdAsync(Guid id);
        Task<Category> GetByName(string name);
        Task UpdateAsync(Category entity);
        Task AddAsync(Category entity);
        Task DeleteAsync(Category entity);
        Task<Result> CheckIfCategoryIsUnique(Category entity);
        Task<Result> CheckIfCategoryCanBeDeleted(Category category);
    }
}
