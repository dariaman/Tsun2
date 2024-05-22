using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Middleware.BaseClass
{
    public record BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        [Column("is_delete")]
        public bool IsDelete { get; set; } = false;

        [Column("deleted_date")]
        public DateTime? DeletedDate { get; set; }

        [Column("deleted_by")]
        public string? DeletedBy { get; set; }

        [Column("created_by")]
        public string? CreatedBy { get; set; } = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

        [Column("last_update_by")]
        public string? LastUpdateBy { get; set; }

        [Column("last_update_date")]
        public DateTime? LastUpdateDate { get; set; }
    }
}
