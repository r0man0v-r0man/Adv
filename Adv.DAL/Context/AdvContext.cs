using Adv.DAL.Context.Interfaces;
using Adv.DAL.Entities;
using Adv.DAL.Entities.Common;
using Adv.DAL.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Adv.DAL.Context.Extensions;

namespace Adv.DAL.Context
{
    public class AdvContext : DbContext, IAdvContext
    {
        public DbSet<Flat> Flats { get; set; }

        public AdvContext(DbContextOptions<AdvContext> options) : base (options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FlatConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.ApplyAuditableInformation();
            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
