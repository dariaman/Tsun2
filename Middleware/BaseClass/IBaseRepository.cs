namespace Middleware.BaseClass
{
    public interface IBaseRepository<TModel> where TModel : BaseModel
    {
        public Task<TModel?> FindByIdAsync(int Id);
        public Task<TModel> InsertAsync(TModel Tmodel);
        public Task<TModel> UpdateAsync(TModel Tmodel);
        public Task<TModel> DeleteAsync(TModel Tmodel);

        IQueryable<TModel> BaseQuery();

    }
}
