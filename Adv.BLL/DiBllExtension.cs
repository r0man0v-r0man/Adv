using Adv.BLL.Interfaces;
using Adv.BLL.Services;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;


namespace Adv.BLL
{
    public static class DiBllExtension
    {
        public static IServiceCollection AddBll(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BllMapProfile));
            services.AddScoped<ISuperManager, SuperManager>();
            services.AddTransient<IFlatService, FlatService>();
            services.AddTransient<IFileService, FileService>();
            return services;
        }
    }
}
