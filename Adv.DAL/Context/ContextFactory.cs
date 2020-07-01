using Adv.DAL.Context.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Adv.DAL.Context
{
    public class ContextFactory : IContextFactory
    {
        public ContextFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }



        public IAdvContext GetAdvContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AdvContext>();
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("AdvConnection"));

            return new AdvContext(optionsBuilder.Options);
        }


        public void Dispose()
        {
        }
    }
}
