using Adv.DAL.Context;
using Adv.DAL.Context.Interfaces;
using Adv.DAL.Entities;
using Adv.DAL.Exceptions;
using Adv.DAL.Interfaces;
using Adv.DAL.Interfaces.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Adv.DAL
{
    public static class DiDalExtension
    {
        public static IServiceCollection AddDal(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<AdvContext>(options =>
            {
                var connection = configuration.GetConnectionString("AdvConnection");

                options.UseSqlServer(connection);
            });
            services.AddTransient<IContextFactory, ContextFactory>();

            services.Configure<PasswordHasherOptions>(options =>
            {
                options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3;
            });
            services.AddIdentity<AppUser, IdentityRole>(config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<AdvContext>()
                .AddDefaultTokenProviders();

            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IFileRepository), typeof(FileRepository));
            services.AddScoped(typeof(IAdvertRepository), typeof(AdvertRepository));
            services.AddTransient<IdentityErrorDescriber, RussianIdentityErrorDescriber>();

            return services;
        }
    }
}
