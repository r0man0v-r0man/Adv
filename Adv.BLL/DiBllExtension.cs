using System;
using System.Collections.Generic;
using System.Text;
using Adv.BLL.Interfaces;
using Adv.BLL.Services;
using Microsoft.Extensions.DependencyInjection;


namespace Adv.BLL
{
    public static class DiBllExtension
    {
        public static IServiceCollection AddBll(this IServiceCollection services)
        {
            services.AddScoped<ISuperManager, SuperManager>();
            services.AddScoped<IFlatService, FlatService>();
            return services;
        }
    }
}
