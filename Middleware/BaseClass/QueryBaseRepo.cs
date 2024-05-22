using Microsoft.EntityFrameworkCore;

namespace Middleware.BaseClass
{
    public class QueryBaseRepo<TModel, TDatabase>(TDatabase tsunDB)
        where TModel : BaseModel
        where TDatabase : DbContext
    {
        public readonly TDatabase _tsunDB = tsunDB;

        public IQueryable<TModel> BaseQuery() => _tsunDB.Set<TModel>().Where(x => !x.IsDelete && x.IsActive);

        public async Task<TModel?> FindByIdAsync(int Id)
        {
            TModel? existingTModel = await _tsunDB.Set<TModel>().SingleOrDefaultAsync(x => x.Id.Equals(Id));
            return existingTModel;
        }
    }
}
