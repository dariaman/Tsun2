using Microsoft.EntityFrameworkCore;
using User.Model;

namespace User.Database
{
    public class TsunUserDB : DbContext
    {

        public DbSet<UserProfileModel> UserProfileModel { get; set; }
        public TsunUserDB(DbContextOptions<TsunUserDB> options) : base(options)
        { }
    }
}
