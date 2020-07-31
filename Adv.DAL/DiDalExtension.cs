using System.IO;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Adv.DAL.Context;
using Adv.DAL.Context.Interfaces;
using Adv.DAL.Entities;
using Adv.DAL.Exceptions;
using Adv.DAL.Interfaces;
using Adv.DAL.Interfaces.Implementations;
using Imgur.API.Authentication;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints;
using Imgur.API.Endpoints.Impl;
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
                options.UseNpgsql(connection);
                // options.UseNpgsql(connection, b=>b.RemoteCertificateValidationCallback(RemoteCertificateValidationCallback));
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
            services.AddScoped(typeof(IYandexAddressRepository), typeof(YandexAddressRepository));
            services.AddTransient<IdentityErrorDescriber, RussianIdentityErrorDescriber>();

            var imgurClientId = configuration.GetValue<string>("Imgur:ClientId");
            var imgurClientSecretId = configuration.GetValue<string>("Imgur:ClientSecretKey");

            var imgurClient = new ImgurClient(imgurClientId, imgurClientSecretId);
            var imgurEndpoint = new ImageEndpoint(imgurClient);

            services.AddSingleton<IImgurClient>(imgurClient);
            services.AddSingleton<IImageEndpoint>(imgurEndpoint);

            return services;
        }



        static bool RemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain defaultChain, SslPolicyErrors defaultErrors)
        {
            string text1 = File.ReadAllText("CA1.pem");
            string text2 = File.ReadAllText("CA2.pem");

            X509Certificate2 ca1Cert = new X509Certificate2(Encoding.UTF8.GetBytes(text1));
            X509Certificate2 ca2Cert = new X509Certificate2(Encoding.UTF8.GetBytes(text2));

            X509Chain caCertChain = new X509Chain();
            caCertChain.ChainPolicy = new X509ChainPolicy()
            {
                RevocationMode = X509RevocationMode.NoCheck,
                RevocationFlag = X509RevocationFlag.EntireChain,
            };

            caCertChain.ChainPolicy.ExtraStore.Add(ca1Cert);
            caCertChain.ChainPolicy.ExtraStore.Add(ca2Cert);

            X509Certificate2 serverCert = new X509Certificate2(certificate);

            caCertChain.Build(serverCert);

            if (caCertChain.ChainStatus.Length == 0)
            {
                // No errors
                return true;
            }

            foreach (X509ChainStatus status in caCertChain.ChainStatus)
            {
                // Check if we got any errors other than UntrustedRoot (which we will always get if we don't install the CA cert to the system store)
                if (status.Status != X509ChainStatusFlags.UntrustedRoot)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
