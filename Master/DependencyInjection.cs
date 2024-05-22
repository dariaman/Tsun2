using FluentValidation;
using FluentValidation.AspNetCore;
using Master.Database;
using Master.Interface;
using Master.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Master
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterMasterDI(this IServiceCollection services)
        {
            var connectionString = "server=154.41.241.2;user=u736239518_tsun;password=EX!hmdN1Ol];database=u736239518_tsundb";
            var dbVersion = new MySqlServerVersion(new Version(8, 0, 36));

            // Repository DI
            //services.AddScoped<IKabupatenRepo, KabupatenRepo>();

            // Service DI
            services.AddScoped<IBankService, BankService>();
            //services.AddScoped<IKabupatenService, KabupatenService>();

            return services
                .AddDbContext<TsunMasterDB>(dbContextOptions => dbContextOptions
                    .UseMySql(connectionString, dbVersion)
                    // The following three options help with debugging, but should be changed or removed for production.
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors())
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
