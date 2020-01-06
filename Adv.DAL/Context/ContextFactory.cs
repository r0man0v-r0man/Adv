using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Adv.DAL.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<AdvContext>
    {
        public AdvContext CreateDbContext(string[] args)
        {
            string connectionString = ReadAdvConnectionStringFromAppSettings();
            

            var builder = new DbContextOptionsBuilder<AdvContext>();
            builder.UseSqlServer(connectionString);
            return new AdvContext(builder.Options);
        }

        private string ReadAdvConnectionStringFromAppSettings()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("AdvConnection");
            return connectionString;
        }
    }
}
