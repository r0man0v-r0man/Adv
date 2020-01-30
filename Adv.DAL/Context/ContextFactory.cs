using Adv.DAL.Context.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Adv.DAL.Context
{
    public sealed class ContextFactory : IContextFactory
    {
        public ContextFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Dispose()
        {
        }

        public IAdvContext GetAdvContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AdvContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("AdvConnection"));

            return new AdvContext(optionsBuilder.Options);
        } 
    }
}
