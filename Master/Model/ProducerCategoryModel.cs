using Middleware.BaseClass;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Master.Model
{
    [Table("m_producer_category")]
    public record class ProducerCategoryModel : BaseModel
    {
        [Required]
        [Column("category_name")]
        public string CategoryName { get; set; }
    }
}
