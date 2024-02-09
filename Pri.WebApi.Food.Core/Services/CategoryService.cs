using Microsoft.EntityFrameworkCore;
using Pri.WebApi.Food.Core.Data;
using Pri.WebApi.Food.Core.Entities;
using Pri.WebApi.Food.Core.Services.Interfaces;
using Pri.WebApi.Food.Core.Services.Models;
using System.Data.Common;

namespace Pri.WebApi.Food.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CategoryService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ResultModel<Category>> AddAsync(Category entity)
        {
            //does categoryname exist?
            if (await DoesCategoryNameExistsAsync(entity))
            {
                return new ResultModel<Category>
                {
                    Errors = new List<string>
              { $"A category with the name {entity.Name} already exists!" },
                };
            }
            entity.CreatedOn = DateTime.UtcNow;
            entity.LastEditedOn = DateTime.UtcNow;
            _applicationDbContext.Categories.Add(entity);
            await _applicationDbContext.SaveChangesAsync();
            return new ResultModel<Category> { Data = entity };
        }

        public async Task<ResultModel<Category>> DeleteAsync(Category entity)
        {
            _applicationDbContext.Categories.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
            return new ResultModel<Category> { Data = entity };
        }

        public async Task<bool> DoesCategoryIdExistsAsync(Guid id)
        {
            return await _applicationDbContext.Categories.AnyAsync(c => c.Id.Equals(id));
        }
        public async Task<bool> DoesCategoryNameExistsAsync(Category Entity)
        {
            return await _applicationDbContext.Categories
                   .Where(c => c.Id != Entity.Id)
                   .AnyAsync(c => c.Name.Equals(Entity.Name));
        }

        public IQueryable<Category> GetAll()
        {
            return _applicationDbContext.Categories;
        }



        public async Task<ResultModel<Category>> GetByIdAsync(Guid id)
        {
            var resultModel = new ResultModel<Category>();
            var category = await _applicationDbContext.Categories
               .FirstOrDefaultAsync(category => category.Id.Equals(id));
            if (category is null)
            {
                resultModel = new ResultModel<Category>();
                resultModel.Errors.Add($"Category does not exists");
                return resultModel;
            }
            resultModel = new ResultModel<Category> { Data = category };
            return resultModel;
        }

        public async Task<ResultModel<IEnumerable<Category>>> GetByName(string name)
        {
            var categories = await _applicationDbContext.Categories
               .Where(c => c.Name.Contains(name)).ToListAsync();
            return new ResultModel<IEnumerable<Category>> { Data = categories };
        }

        public async Task<ResultModel<IEnumerable<Category>>> ListAllAsync()
        {
            var categories = await _applicationDbContext.Categories.ToListAsync();
            return new ResultModel<IEnumerable<Category>> { Data = categories };
        }

        public async Task<ResultModel<Category>> UpdateAsync(Category entity)
        {
            //does category id exist?
            if (!await DoesCategoryIdExistsAsync(entity.Id))
            {
                return new ResultModel<Category>
                {
                    Errors = new List<string> { $"There is no category with id :{entity.Id}" }
                };
            }
            //does another category with same name exist?
            if (await DoesCategoryNameExistsAsync(entity))
            {
                return new ResultModel<Category>
                {
                    Errors = new List<string> { $"There is already category with id :{entity.Id}" }
                };
            }
            entity.LastEditedOn = DateTime.UtcNow;
            _applicationDbContext.Categories.Update(entity);
            await _applicationDbContext.SaveChangesAsync();
            return new ResultModel<Category>
            {
                Data = entity
            };
        }
    }
}
