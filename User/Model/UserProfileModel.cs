using Middleware.BaseClass;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.Model
{
    [Table("user_profile")]
    public record UserProfileModel : BaseModel
    {
        public string Fullname { get; set; }
        public string Email { get; set; }

    }
}
