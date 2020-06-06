using Adv.BLL;
using Adv.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Adv.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddCors();
            services.AddApi(Configuration);
            services.AddBll();
            services.AddDal(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(options => { options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
            }
            //app.UseHsts();
            //app.UseHttpsRedirection();

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseCors(options => {
                    options.WithOrigins("https://halupa.by").AllowAnyHeader().AllowAnyMethod();
                });
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            //who are you?
            app.UseAuthentication();
         
            //are you allowed?
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                spa.UseSpaPrerendering(options =>
                {
                    options.BootModulePath = $"{spa.Options.SourcePath}/dist/server/main.js";
                    options.BootModuleBuilder = env.IsDevelopment()
                        ? new AngularCliBuilder(npmScript: "build:ssr")
                        : null;
                    options.ExcludeUrls = new[] { "/sockjs-node" };
                });

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
