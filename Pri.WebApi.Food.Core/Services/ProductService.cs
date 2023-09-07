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

        public Task<Product> UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> AddAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> DeleteAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
