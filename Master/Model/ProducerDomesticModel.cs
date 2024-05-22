using Middleware.BaseClass;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Master.Model
{
    [Table("m_producer_domestic")]
    public record ProducerDomesticModel : BaseModel
    {
        [Required]
        [Column("domestic_name")]
        public string DomesticName { get; set; }
    }
}
