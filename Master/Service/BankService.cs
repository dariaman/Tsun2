using Master.Database;
using Master.Interface;
using Master.Mapper;
using Master.Model;
using Master.ParamRequest;
using Microsoft.EntityFrameworkCore;
using Middleware.BaseClass;
using Middleware.Interface;

namespace Master.Service
{
    public class BankService(ICrudBaseRepo<BankModel, TsunMasterDB> crudRepo) : IBankService
    {

        private readonly ICrudBaseRepo<BankModel, TsunMasterDB> _crudRepo = crudRepo;

        public async Task<BankModel> CreateAsync(BankCreateReq bankCreateReq)
        {
            return await _crudRepo.InsertAsync(bankCreateReq.MapToBankModel());
        }

        public async Task<List<DropdownListData>> DropdownListAsync()
        {
            return await _crudRepo.BaseQuery()
                .Select(x => new DropdownListData() { Id = x.Id, Description = x.BankName }).ToListAsync();
        }
    }
}
