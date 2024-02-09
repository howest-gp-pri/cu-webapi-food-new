using Pri.WebApi.Food.Core.Entities;
using Pri.WebApi.Food.Core.Services.Models;

namespace Pri.WebApi.Food.Core.Services.Interfaces
{
    
        public interface ICategoryService
        {
            IQueryable<Category> GetAll();
            Task<ResultModel<IEnumerable<Category>>> ListAllAsync();
            Task<ResultModel<Category>> GetByIdAsync(Guid id);
            Task<bool> DoesCategoryIdExistsAsync(Guid id);
            Task<bool> DoesCategoryNameExistsAsync(Category Entity);
            Task<ResultModel<IEnumerable<Category>>> GetByName(string name);
            Task<ResultModel<Category>> UpdateAsync(Category entity);
            Task<ResultModel<Category>> AddAsync(Category entity);
            Task<ResultModel<Category>> DeleteAsync(Category entity);
        }
    }

