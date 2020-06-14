using Adv.DAL.Context.Interfaces;
using Adv.DAL.Entities;
using Adv.DAL.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Adv.DAL.Context.Extensions;
using Adv.DAL.Entities.Adverts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Adv.DAL.Context
{
    // IdentityDbCOntext contains all the AppUser tables
    public class AdvContext : IdentityDbContext<AppUser>, IAdvContext
    {
        public DbSet<FlatRent> FlatRents { get; set; }
        public DbSet<FlatSale> FlatSales { get; set; }
        public DbSet<HouseRent> HouseRents { get; set; }
        public DbSet<HouseSale> HouseSales { get; set; }
        public DbSet<City> Cities { get; set; }

        public AdvContext(DbContextOptions<AdvContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder?.ApplyConfiguration(new FlatSaleConfiguration());
            modelBuilder?.ApplyConfiguration(new FlatRentConfiguration());
            modelBuilder?.ApplyConfiguration(new HouseRentConfiguration());
            modelBuilder?.ApplyConfiguration(new HouseSaleConfiguration());
            modelBuilder?.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder?.ApplyConfiguration(new CityConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.ApplyAuditableInformation();
            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

    }
}
