using Adv.DAL.Context;
using Adv.DAL.Entities;
using Adv.DAL.Interfaces;
using Adv.DAL.Interfaces.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Adv.DAL
{
    public static class DiDalExtension
    {
        public static IServiceCollection AddDal(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("AdvConnection")));
            services.AddScoped<IRepository<Flat>, Repository<Flat>>();

            return services;
        }
    }
}
