using Adv.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DAL.EntitiesConfigurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder
                .HasMany(prop => prop.FlatRents)
                .WithOne(prop => prop.AppUser);
            builder
                .HasMany(prop => prop.FlatSales)
                .WithOne(prop => prop.AppUser);
            builder
                .HasMany(prop => prop.HouseRents)
                .WithOne(prop => prop.AppUser);
        }
    }
}
