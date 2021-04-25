using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StellarPayRoll.Core.Domain.Identity;
using StellarPayRoll.Core.Domain.Repositories;
using StellarPayRoll.Core.Domain.Services;
using StellarPayRoll.Core.Models.Entities;
using StellarPayRoll.Data.Context;
using StellarPayRoll.Domain.Identity;
using StellarPayRoll.Domain.Repositories;
using StellarPayRoll.Domain.Services;

namespace StellarPayRoll.IOC.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDBContext>(options => options.UseMySql(connectionString));

            return services;

        }

        public static IServiceCollection AddCustomIdentity(this IServiceCollection services)
        {
            services.AddScoped<IUserStore<User>, UserStore>();

            services.AddScoped<IRoleStore<Role>, RoleStore>();

            services.AddIdentity<User, Role>().AddDefaultTokenProviders();

            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IRoleService, RoleService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IRoleRepository, RoleRepository>();

            return services;
        }
    }
}
