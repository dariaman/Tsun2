using Microsoft.EntityFrameworkCore;
using Middleware.BaseClass;

namespace Middleware.Interface
{
    public interface ICrudBaseRepo<TModel, TDatabase> 
        where TModel : BaseModel
        where TDatabase : DbContext
    {
        IQueryable<TModel> BaseQuery();
        Task<TModel?> FindByIdAsync(int Id);
        Task<TModel> InsertAsync(TModel Tmodel);
        Task<TModel> UpdateAsync(TModel Tmodel);
        Task<TModel> DeleteAsync(TModel Tmodel);
    }
}
