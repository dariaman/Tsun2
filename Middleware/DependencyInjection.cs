using Microsoft.Extensions.DependencyInjection;
using Middleware.BaseClass;
using Middleware.Interface;

namespace Middleware
{
    public static class DependencyInjection
    {
        public static IServiceCollection MiddlewareDI(this IServiceCollection services)
        {
            services.AddTransient(typeof(ICrudBaseRepo<,>), typeof(CrudBaseRepo<,>));
            //services.AddTransient(typeof(IQueryBaseRepo<,>), typeof(QueryBaseRepo<,>));

            return services;
        }
    }
}
