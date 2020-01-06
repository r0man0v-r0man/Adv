﻿using Adv.DAL.Context;
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
            var connection = configuration["AdvConnection"];
            services.AddDbContextPool<AdvContext>(options =>
            {
                options.UseSqlServer(connection);
            });

            services.AddIdentity<IdentityUser, IdentityRole>(config => {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<AdvContext>()
                .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "HalupaIdentityCookie";
            });
            services.AddScoped<IDataManager, DataManager>();
            services.AddTransient(typeof(IFlatRepository), typeof(FlatRepository));

            return services;
        }
    }
}
