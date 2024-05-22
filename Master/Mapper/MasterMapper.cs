using Master.Model;
using Master.ParamRequest;

namespace Master.Mapper
{
    public static class MasterMapper
    {
        public static KabupatenModel MapToKabupatenModel(this KabupatenCreateReq kabupatenCreateReq)
        {
            return new KabupatenModel()
            {
                ProvinsiId = kabupatenCreateReq.ProvinsiId,
                KabupatenName = kabupatenCreateReq.KabupatenName,
                KabupatenFl = kabupatenCreateReq.KabupatenFl
            };
        }

        public static BankModel MapToBankModel(this BankCreateReq bankCreateReq)
        {
            return new BankModel()
            {
                BankName = bankCreateReq.BankName
            };
        }
    }
}
