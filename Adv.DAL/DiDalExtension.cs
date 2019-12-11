
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
            var connection = configuration.GetConnectionString("AdvConnection");
            services.AddDbContextPool<AdvContext>(options => options.UseSqlServer(connection));
            services.AddTransient<IDataManager, DataManager>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
