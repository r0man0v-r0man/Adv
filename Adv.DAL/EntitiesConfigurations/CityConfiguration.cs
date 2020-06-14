using Adv.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DAL.EntitiesConfigurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder
                .HasMany(prop => prop.FlatRents)
                .WithOne(prop => prop.City);
            builder
                .HasMany(prop => prop.FlatSales)
                .WithOne(prop => prop.City);
            builder
                            .HasMany(prop => prop.HouseRents)
                            .WithOne(prop => prop.City);
            builder
                            .HasMany(prop => prop.HouseSales)
                            .WithOne(prop => prop.City);

        }
    }
}
