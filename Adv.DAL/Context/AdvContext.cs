﻿using Adv.DAL.Context.Interfaces;
using Adv.DAL.Entities;
using Adv.DAL.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Adv.DAL.Context.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Adv.DAL.Context
{
    // IdentityDbCOntext contains all the user tables
    public class AdvContext : IdentityDbContext, IAdvContext
    {
        //
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
