using Adv.BLL.Interfaces;
using Adv.BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using FileService = Adv.BLL.Services.FileService;

namespace Adv.BLL
{
    public static class DiBllExtension
    {
        public static IServiceCollection AddBll(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdvertService, AdvertService>();
            services.AddScoped<IYandexAddressService, YandexAddressService>();
            services.AddScoped<ISitemapService, SitemapService>();

            services.AddMemoryCache();

            return services;
        }
    }
}
