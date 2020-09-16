using Adv.BLL.Interfaces;
using Adv.BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Stripe;
using FileService = Adv.BLL.Services.FileService;

namespace Adv.BLL
{
    public static class DiBllExtension
    {
        public static IServiceCollection AddBll(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdvertService, AdvertService>();
            services.AddScoped<IYandexAddressService, YandexAddressService>();
            services.AddScoped<ISitemapService, SitemapService>();

            services.AddMemoryCache();

            // payment Stripe
            var stripeSecretApiKey = configuration?.GetSection("Stripe")["SecretKey"];
            services.AddSingleton<IStripeClient, StripeClient>(s => new StripeClient(stripeSecretApiKey));
            services.AddSingleton<IPaymentService, PaymentService>();
            return services;
        }
    }
}
