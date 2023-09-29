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
        Task<Category> UpdateAsync(Category entity);
        Task<Category> AddAsync(Category entity);
        Task<Category> DeleteAsync(Category entity);
        Task<Result> CheckIfCategoryIsUnique(Category entity);
        Task<Result> CheckIfCategoryCanBeDeleted(Category category);
    }
}
