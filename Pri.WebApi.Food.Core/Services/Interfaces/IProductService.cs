using Pri.WebApi.Food.Core.Entities;
using Pri.WebApi.Food.Core.Services.Models;

namespace Pri.WebApi.Food.Core.Services.Interfaces
{
   
        public interface IProductService
        {
            IQueryable<Product> GetAll();
            Task<ResultModel<IEnumerable<Product>>> ListAllAsync();
            Task<ResultModel<Product>> GetByIdAsync(Guid id);
            Task<ResultModel<Product>> UpdateAsync(Product entity);
            Task<ResultModel<Product>> AddAsync(Product entity);
            Task<ResultModel<Product>> DeleteAsync(Product entity);
            Task<ResultModel<IEnumerable<Product>>> GetByCategoryIdAsync(Guid id);
            Task<ResultModel<IEnumerable<Product>>> SearchAsync(string search);
            Task<bool> DoesProductIdExistAsync(Guid id);
            Task<bool> DoesProductNameExistsAsync(Product entity);
        }

    }

