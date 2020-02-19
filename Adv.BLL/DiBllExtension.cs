using Adv.BLL.Exceptions;
using Adv.BLL.Interfaces;
using Adv.BLL.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;


namespace Adv.BLL
{
    public static class DiBllExtension
    {
        public static IServiceCollection AddBll(this IServiceCollection services)
        {
            services.AddTransient<IFlatService, FlatService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IdentityErrorDescriber, RussianIdentityErrorDescriber>();


            return services;
        }
    }
}
