using Microsoft.EntityFrameworkCore;
using Pri.WebApi.Food.Core.Data;
using Pri.WebApi.Food.Core.Entities;
using Pri.WebApi.Food.Core.Services.Interfaces;

namespace Pri.WebApi.Food.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext dbContext;

        public ProductService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Product> GetAll()
        {
            return dbContext.Products.Include(p => p.Category);
        }

        public async Task<IEnumerable<Product>> ListAllAsync()
        {
            var products = await GetAll().ToListAsync();
            return products;
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            var product = await GetAll().SingleOrDefaultAsync(p => p.Id.Equals(id));
            return product;
        }

        public async Task<IEnumerable<Product>> GetByCategoryIdAsync(Guid id)
        {
            var products = await GetAll().Where(p => p.CategoryId.Equals(id)).ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> SearchAsync(string search)
        {
            var products = await GetAll()
                .Where(p => p.Name.Contains(search.Trim().ToUpper()) || p.Category.Name.Contains(search.Trim().ToUpper()))
                .ToListAsync();

            return products;
        }

        public async Task UpdateAsync(Product entity)
        {
            try
            {
                entity.LastEditedOn = DateTime.UtcNow;

                dbContext.Products.Update(entity);
                await dbContext.SaveChangesAsync();

            }
            catch(DbUpdateException dbException)
            {
                throw dbException;
            }
        }

        public async Task AddAsync(Product entity)
        {
            var now = DateTime.UtcNow;
            entity.CreatedOn = now;
            entity.LastEditedOn = now;

            dbContext.Products.Add(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product entity)
        {
            try
            {
                dbContext.Products.Remove(entity);
                await dbContext.SaveChangesAsync();
            }
            catch(DbUpdateException dbException)
            {
                throw dbException;
            }
        }
    }
}
