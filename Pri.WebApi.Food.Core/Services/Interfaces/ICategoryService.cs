using Pri.WebApi.Food.Core.Entities;
using Pri.WebApi.Food.Core.Services.Models;

namespace Pri.WebApi.Food.Core.Services.Interfaces
{
    public interface ICategoryService
    {
        IQueryable<Category>> GetAll();
        Task<Result<IEnumerable<Category>>> ListAllAsync();
        Task<Result<Category>> GetByIdAsync(Guid id);
        Task<Result> UpdateAsync(Category entity);
        Task<Result<Category>> AddAsync(Category entity);
        Task<Result> DeleteAsync(Category entity);
    }
}
