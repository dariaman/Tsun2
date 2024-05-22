using Microsoft.EntityFrameworkCore;
using Middleware.Interface;
using Middleware.Pagination;

namespace Middleware.BaseClass
{
    public abstract class PaginationBase<TModel, TDatabase>(TDatabase tsunDB) : QueryBaseRepo<TModel, TDatabase>(tsunDB)
        where TModel : BaseModel
        where TDatabase : DbContext
    {
        public readonly TDatabase _tsunDB = tsunDB;

        public IQueryable<TModel> PageQuery(PagingRequest pageRequest)
        {
            var query = this.BaseQuery();

            pageRequest.Search.ForEach(itemFilter =>
            {
                var search = itemFilter.MapToFilterCriteria();

                if (search.Operator == OperatorEnm.Between)
                {
                    var (startFilter, endFilter) = itemFilter.MapToFilterBetweenCriteria();
                    query = query.FilterQuery(startFilter);
                    query = query.FilterQuery(endFilter);
                }
                else query = query.FilterQuery(search);
            });

            // add order to query
            pageRequest.Sort.ForEach(srt => query = query.OrderByQuery(srt.PropertyNameOrder, srt.IsAscending));

            return query;
        }

        public PagingResponse<TModel> ToPagedList(IQueryable<TModel> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagingResponse<TModel>(items, count, pageNumber, pageSize);
        }

        public PagingResponse<TModel> PageData(PagingRequest pageRequest)
        {
            var query = PageQuery(pageRequest);
            return ToPagedList(query, pageRequest.PageIndex, pageRequest.PageSize);
        }

    }
}
