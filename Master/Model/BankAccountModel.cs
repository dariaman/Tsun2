using Middleware.BaseClass;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Master.Model
{
    [Table("m_bank_account")]
    public record BankAccountModel : BaseModel
    {
        [Required]
        [Column("bank_id")]
        public int BankId { get; set; }

        [Required]
        [Column("account_number")]
        public string AccountNumber { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }
}
