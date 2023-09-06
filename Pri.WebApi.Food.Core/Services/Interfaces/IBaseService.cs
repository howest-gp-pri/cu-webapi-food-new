using Pri.WebApi.Food.Core.Entities;

namespace Pri.WebApi.Food.Core.Services.Interfaces
{
    public interface IBaseService<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<IEnumerable<T>> ListAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> UpdateAsync(T entity);
        Task<T> AddAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}