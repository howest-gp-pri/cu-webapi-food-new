using Pri.WebApi.Food.Api.Data;
using Pri.WebApi.Food.Api.Entities;
using Pri.WebApi.Food.Api.Services.Interfaces;

namespace Pri.WebApi.Food.Api.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
