using Microsoft.EntityFrameworkCore;
using Pri.WebApi.Food.Core.Data;
using Pri.WebApi.Food.Core.Entities;
using Pri.WebApi.Food.Core.Services.Interfaces;
using Pri.WebApi.Food.Core.Services.Models;

namespace Pri.WebApi.Food.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IQueryable<Category> GetAll()
        {
            return dbContext.Categories.AsQueryable();
        }
        public async Task<Result<IEnumerable<Category>>> ListAllAsync()
        {
            var result = await dbContext.Categories.ToListAsync();
            return new Result<IEnumerable<Category>> { Data = result };
        }

        public async Task<Result<Category>> GetByIdAsync(Guid id)
        {
            var result = await dbContext.Categories
                .FirstOrDefaultAsync(category => category.Id.Equals(id));

            if(result is not null) return new Result<Category> { Data = result };

            return new Result<Category>
            {
                Success = false,
                Errors = new List<string> { $"The category with id {id} does not exists." }
            };
        }
        public async Task<Result> UpdateAsync(Category entity)
        {
            Result result = new Result();

            bool categoryNameExists = await dbContext.Categories
                .AnyAsync(category => category.Name.ToUpper() == entity.Name);

            if (categoryNameExists) 
                result.Errors.Add("A category with this name already exists.");

            var entityToUpdate = await dbContext.Categories
                .FirstOrDefaultAsync(category => category.Id.Equals(entity.Id));

            if (entityToUpdate is null)
                result.Errors.Add($"The specified category (id: {entity.Id}) you want to update does not exist.");

            if (result.Success)
            {
                entity.LastEditedOn = DateTime.UtcNow;
                dbContext.Categories.Update(entity);
                await dbContext.SaveChangesAsync();
            }

            return result;

        }

        public async Task<Result<Category>> AddAsync(Category entity)
        {
            Result<Category> result = new Result<Category>();

            bool categoryNameExists = await dbContext.Categories
                .AnyAsync(category => category.Name.ToUpper() == entity.Name);

            if (categoryNameExists)
                result.Errors.Add("A category with this name already exists.");

            if (result.Errors.Any())
            {
                result.Success = false;
                return result;
            }

            else
            {
                DateTime now = DateTime.UtcNow;
                entity.CreatedOn = now;
                entity.LastEditedOn = now;

                dbContext.Categories.Add(entity);
                await dbContext.SaveChangesAsync();

                return new Result<Category> { Data = entity };
            }
        }

        public async Task<Result> DeleteAsync(Category entity)
        {
            Result result = new Result();

            bool categoryHasProducts = dbContext.Products
                .Any(product => product.CategoryId.Equals(entity.Id));

            if (categoryHasProducts)
            {
                result.Success = false;
                result.Errors.Add("Unable to delete category. This still has products linked.");

                return result;
            }
            
            else
            {
                dbContext.Categories.Remove(entity);
                await dbContext.SaveChangesAsync();

                return new Result();
            }
        }
    }
}
