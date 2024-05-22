using Middleware.BaseClass;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Master.Model
{
    [Table("m_country")]
    public record CountryModel : BaseModel
    {
        [Required]
        [Column("country_name")]
        public string CountryName { get; set; }
    }
}
