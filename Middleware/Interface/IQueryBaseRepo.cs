using Microsoft.EntityFrameworkCore;
using Middleware.BaseClass;

namespace Middleware.Interface
{
    public interface IQueryBaseRepo<TModel, TDatabase> 
        where TModel : BaseModel
        where TDatabase : DbContext
    {
        IQueryable<TModel> BaseQuery();
        Task<TModel?> FindByIdAsync(int Id);

    }
}
