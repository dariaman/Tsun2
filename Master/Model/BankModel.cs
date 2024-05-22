using Middleware.BaseClass;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Master.Model
{
    [Table("m_bank")]
    public record BankModel : BaseModel
    {
        [Required]
        [Column("bank_name")]
        public string BankName { get; set; }
    }
}
