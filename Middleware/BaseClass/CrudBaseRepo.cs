using Microsoft.EntityFrameworkCore;
using Middleware.Interface;

namespace Middleware.BaseClass
{
    public class CrudBaseRepo<TModel, TDatabase>(TDatabase tsunDB) : ICrudBaseRepo<TModel, TDatabase>
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

        public async Task<TModel> InsertAsync(TModel tModel)
        {
            tModel.CreatedBy = "Not Setting yet";
            _tsunDB.Set<TModel>().Add(tModel);
            await _tsunDB.SaveChangesAsync();
            return tModel;
        }

        public async Task<TModel> UpdateAsync(TModel tModel)
        {
            _ = await this.FindByIdAsync(tModel.Id) ?? throw new DbUpdateException("No Data Found");

            tModel.LastUpdateBy = "Not Setting yet";
            tModel.LastUpdateDate = DateTime.Now;
            _tsunDB.Set<TModel>().Update(tModel);
            await _tsunDB.SaveChangesAsync();
            return tModel;
        }

        public async Task<TModel> DeleteAsync(TModel tModel)
        {
            TModel? existingTModel = await this.FindByIdAsync(tModel.Id) ?? throw new DbUpdateException("No Data Found");

            tModel.IsDelete = true;
            tModel.DeletedDate = DateTime.Now;
            tModel.DeletedBy = "Not Setting yet";

            await UpdateAsync(tModel);

            return existingTModel;
        }
    }
}