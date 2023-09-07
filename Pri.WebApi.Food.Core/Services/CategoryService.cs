using Microsoft.EntityFrameworkCore;
using Pri.WebApi.Food.Core.Data;
using Pri.WebApi.Food.Core.Entities;
using Pri.WebApi.Food.Core.Services.Interfaces;

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
            return await GetAll().ToListAsync();
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            return await dbContext.Categories.SingleOrDefaultAsync(category => category.Id.Equals(id));
        }
        public async Task<Category> UpdateAsync(Category entity)
        {
            entity.LastEditedOn = DateTime.UtcNow;

            dbContext.Categories.Update(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Category> AddAsync(Category entity)
        {
            var now = DateTime.UtcNow;
            entity.CreatedOn = now;
            entity.LastEditedOn = now;

            dbContext.Categories.Add(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Category> DeleteAsync(Category entity)
        {
            dbContext.Categories.Remove(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }


    }
}
