using Adv.API.Additional;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adv.API
{
    public static class DiApiExtension
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(ViewModelMapProfile));

            return services;
        }
    }
}
