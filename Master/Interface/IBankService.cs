using Master.Model;
using Master.ParamRequest;
using Middleware.BaseClass;

namespace Master.Interface
{
    public interface IBankService
    {
        Task<BankModel> CreateAsync(BankCreateReq bankCreateReq);
        Task<List<DropdownListData>> DropdownListAsync();

    }
}
