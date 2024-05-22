using Middleware.BaseClass;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Master.Model
{
    [Table("m_producer_type")]
    public record  ProducerTypeModel : BaseModel
    {
        [Required]
        [Column("type_name")]
        public string TypeName { get; set; }
    }
}
