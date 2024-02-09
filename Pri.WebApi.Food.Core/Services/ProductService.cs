using Microsoft.EntityFrameworkCore;
using Pri.WebApi.Food.Core.Data;
using Pri.WebApi.Food.Core.Entities;
using Pri.WebApi.Food.Core.Services.Interfaces;
using Pri.WebApi.Food.Core.Services.Models;

namespace Pri.WebApi.Food.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ProductService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ResultModel<Product>> AddAsync(Product entity)
        {
            //does product with same name exist?
            if (await DoesProductNameExistsAsync(entity))
            {
                new ResultModel<Product>
                {
                    Errors = new List<string>
                      { $"There is already a product with name = {entity.Name}" }
                };
            }
            entity.CreatedOn = DateTime.UtcNow;
            entity.LastEditedOn = DateTime.UtcNow;

            _applicationDbContext.Products.Add(entity);
            await _applicationDbContext.SaveChangesAsync();

            return new ResultModel<Product> { Data = entity };
        }

        public async Task<ResultModel<Product>> DeleteAsync(Product entity)
        {
            _applicationDbContext.Products.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
            return new ResultModel<Product>
            {
                Data = entity
            };
        }

        public async Task<bool> DoesProductIdExistAsync(Guid id)
        {
            return await _applicationDbContext.Products.AnyAsync(p => p.Id.Equals(id));
        }



        public async Task<bool> DoesProductNameExistsAsync(Product entity)
        {
            return await _applicationDbContext.Products
                      .Where(p => p.Id != entity.Id)
                      .AnyAsync(p => p.Name.Equals(entity.Name));
        }

        public IQueryable<Product> GetAll()
        {
            return _applicationDbContext.Products.Include(p => p.Category);
        }

        public async Task<ResultModel<IEnumerable<Product>>> GetByCategoryIdAsync(Guid id)
        {
            var products = await _applicationDbContext.Products
                    .Include(p => p.Category)
                    .Where(p => p.CategoryId.Equals(id)).ToListAsync();
            return new ResultModel<IEnumerable<Product>> { Data = products };
        }

        public async Task<ResultModel<Product>> GetByIdAsync(Guid id)
        {
            var product = await _applicationDbContext
                     .Products
                     .Include(p => p.Category)
                     .FirstOrDefaultAsync(p => p.Id == id);
            if (product is null)
            {
                return new ResultModel<Product>
                {
                    Errors = new List<string> { "Product does not exist" }
                };
            }
            return new ResultModel<Product> { Data = product };
        }

        public async Task<ResultModel<IEnumerable<Product>>> ListAllAsync()
        {
            var products = await _applicationDbContext.Products
                .Include(p => p.Category)
                .ToListAsync();
            var resultModel = new ResultModel<IEnumerable<Product>>()
            {
                Data = products,
            };
            return resultModel;
        }

        public async Task<ResultModel<IEnumerable<Product>>> SearchAsync(string search)
        {
            var products = await _applicationDbContext.Products
                                .Include(p => p.Category)
                                .Where(p => p.Name
                        .Contains(search.Trim())
                        || p.Category.Name.Contains(search.Trim())).ToListAsync();
            return new ResultModel<IEnumerable<Product>> { Data = products };
        }



        public async Task<ResultModel<Product>> UpdateAsync(Product entity)
        {
            //product id exists?
            if (!await DoesProductIdExistAsync(entity.Id))
            {
                return new ResultModel<Product>
                {
                    Errors = new List<string> { $"There is no product with id {entity.Id}!" }
                };
            }
            //does product name exist
            if (await DoesProductNameExistsAsync(entity))
            {
                return new ResultModel<Product>
                {
                    Errors = new List<string>
                  { $"There already a product with name {entity.Name}!" }
                };
            }
            //update the entity
            entity.LastEditedOn = DateTime.UtcNow;
            _applicationDbContext.Products.Update(entity);
            await _applicationDbContext.SaveChangesAsync();

            return new ResultModel<Product>
            {
                Data = entity
            };
        }
    }

}
