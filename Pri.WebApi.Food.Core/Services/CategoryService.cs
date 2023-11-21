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
        private readonly ApplicationDbContext dbContext;

        public CategoryService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IQueryable<Category> GetAll()
        {
            return dbContext.Categories.AsQueryable();
        }
        public async Task<IEnumerable<Category>> ListAllAsync()
        {
            var result = await dbContext.Categories.ToListAsync();
            return result;
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            var result = await dbContext.Categories
                .FirstOrDefaultAsync(category => category.Id.Equals(id));

            return result;

        }
        public async Task UpdateAsync(Category entity)
        {
            entity.LastEditedOn = DateTime.UtcNow;

            dbContext.Categories.Update(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddAsync(Category entity)
        {
            DateTime now = DateTime.UtcNow;
            entity.CreatedOn = now;
            entity.LastEditedOn = now;

            dbContext.Categories.Add(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category entity)
        {
            dbContext.Categories.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Result> CheckIfUpdateCategoryIsUnique(Category entity)
        {
            bool categoryNameExists = await dbContext.Categories
                .Where(category => category.Id != entity.Id)
                .AnyAsync(category => category.Name == entity.Name);

            return !categoryNameExists ? new Result() : new Result
            {
                Errors = new List<string>() { "A category with this name already exists" }
            };
        }

        public async Task<Result> CheckIfCategoryCanBeDeleted(Category category)
        {
            Result result = new Result();

            bool categoryHasProducts = await dbContext.Products
                .AnyAsync(product => product.CategoryId.Equals(category.Id));

            if (categoryHasProducts)
            {
                result.Errors.Add("Unable to delete category. This still has products linked.");
            }

            return result;
        }

        public async Task<Category> GetByName(string name)
        {
            var entity = await dbContext.Categories
                .FirstOrDefaultAsync(entity => entity.Name == name);

            return entity;
        }
    }
}
