using Middleware.BaseClass;
using System.ComponentModel.DataAnnotations.Schema;

namespace Master.Model
{
    [Table("m_producer")]
    public record ProducerModel : BaseModel
    {
        [ForeignKey("producer_category_id")]
        public ProducerCategoryModel ProducerCategory { get; set; }

        [ForeignKey("producer_type_id")]
        public ProducerTypeModel ProducerType { get; set; }

        [ForeignKey("producer_domestic_type_id")]
        public ProducerDomesticModel ProducerDomesticType { get; set; }

        [ForeignKey("producer_overseas_type_id")]
        public ProducerOverseasModel ProducerOverseasType { get; set; }

        [Column("producer_network")]
        public string ProducerNetwork { get; set; }

        [Column("producer_name")]
        public string ProducerName { get; set; }

        [Column("producer_address_id")]
        public ProducerAddressModel ProducerAddress { get; set; }

        [ForeignKey("establishment_country_id")]
        public CountryModel EstablishmentCountry { get; set; }

        [Column("establishment_date")]
        public DateTime EstablishmentDate { get; set; }

        [Column("licence_nib")]
        public string LicenseNIB { get; set; }

        [Column("tax_number")]
        public string TaxNumber { get; set; }

        [Column("tax_name")]
        public string TaxName { get; set; }

        [Column("pic_name")]
        public string PicName { get; set; }

        [Column("pic_phone_number")]
        public string PicPhoneNumber { get; set; }

        [Column("agreement_number")]
        public string AgreementNumber { get; set; }

        [Column("agreement_period_start")]
        public DateTime AgreementPeriodStart { get; set; }

        [Column("agreement_period_end")]
        public DateTime AgreementPeriodEnd { get; set; }

        [ForeignKey("bank_account_id")]
        public BankAccountModel BankAccount { get; set; }
    }
}
