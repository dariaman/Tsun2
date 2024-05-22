using Master.Model;
using Microsoft.EntityFrameworkCore;

namespace Master.Database
{
    public class TsunMasterDB(DbContextOptions<TsunMasterDB> options) : DbContext(options)
    {
        public DbSet<KabupatenModel> KabupatenModel { get; set; }
        public DbSet<CountryModel> CountryModel { get; set; }
        public DbSet<BankModel> BankModel { get; set; }
        public DbSet<BankAccountModel> BankAccountModel { get; set; }
        public DbSet<ProducerDomesticModel> ProducerDomesticModel { get; set; }
        public DbSet<ProducerCategoryModel> ProducerCategoryModel { get; set; }
        public DbSet<ProducerOverseasModel> ProducerOverseasModel { get; set; }
        public DbSet<ProducerTypeModel> ProducerTypeModel { get; set; }
        public DbSet<ProducerModel> ProducerModel { get; set; }
    }
}
