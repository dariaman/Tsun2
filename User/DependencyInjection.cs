using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using User.Database;
using User.Interface;
using User.Service;

namespace User
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterUserDI(this IServiceCollection services)
        {
            var connectionString = "server=localhost;user=app;password=P@ssw0rd;database=tsun";
            var dbVersion = new MySqlServerVersion(new Version(8, 0, 36));

            return services
                .AddDbContext<TsunUserDB>(dbContextOptions => dbContextOptions
                    .UseMySql(connectionString, dbVersion)
                    // The following three options help with debugging, but should be changed or removed for production.
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors())

                //.AddScoped<IUserProfileRepo, UserProfileRepo>()
                .AddScoped<IUserService, UserService>();
        }
    }
}
