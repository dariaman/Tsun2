using Middleware.BaseClass;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Master.Model
{
    [Table("m_producer_overseas")]
    public record ProducerOverseasModel : BaseModel
    {
        [Required]
        [Column("overseas_name")]
        public string OverseasName { get; set; }
    }
}
