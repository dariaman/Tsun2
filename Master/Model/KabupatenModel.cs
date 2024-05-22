using Middleware.BaseClass;
using System.ComponentModel.DataAnnotations.Schema;

namespace Master.Model
{
    [Table("m_kabupaten")]
    public record KabupatenModel : BaseModel
    {
        [Column("m_provinsi_id")]
        public int ProvinsiId { get; set; }

        [Column("m_kabupaten_nama")]
        public string KabupatenName { get; set; }

        [Column("m_kabupaten_fl")]
        public int KabupatenFl { get; set; }

    }
}
