using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StellarPayRoll.Data.Context;

namespace StellarPayRoll.IOC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDBContext>(options =>
                options.UseMySql(connectionString));
            return services;

        }
    }
}
