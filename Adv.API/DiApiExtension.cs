using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace Adv.API
{
    public static class DiApiExtension
    {
        public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
            });
            services.AddAuthentication(options => 
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer(config =>
                {
                    var secretsBytes = Encoding.UTF8.GetBytes(configuration["TokenSecret"]);
                    var key = new SymmetricSecurityKey(secretsBytes);
                    
                    config.Events = new JwtBearerEvents()
                    { 
                        OnMessageReceived = context =>
                        {//for using token via auery string parameters
                            if (context.Request.Query.ContainsKey("access_token"))
                            {
                                context.Token = context.Request.Query["access_token"];
                            }
                            return Task.CompletedTask;
                        }
                    };
                    
                    config.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ClockSkew = TimeSpan.FromMinutes(10),
                        ValidIssuer = configuration["TokenIssuer"],
                        ValidAudience = configuration["TokenAudience"],
                        IssuerSigningKey = key,
                        NameClaimType = JwtRegisteredClaimNames.UniqueName
                    };
                });
            services.AddControllers();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            return services;
        }
    }
}
