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
            services.AddTransient<ISuperManager, SuperManager>();
            services.AddTransient<IFlatService, FlatService>();
            return services;
        }
    }
}
