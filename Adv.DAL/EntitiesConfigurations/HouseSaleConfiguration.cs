using System;
using System.Collections.Generic;
using System.Text;
using Adv.DAL.Entities.Adverts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adv.DAL.EntitiesConfigurations
{
    public class HouseSaleConfiguration : IEntityTypeConfiguration<HouseSale>
    {
        public void Configure(EntityTypeBuilder<HouseSale> builder)
        {
            builder
                .Property(prop => prop.Id)
                .IsRequired();
            builder
                .HasOne(prop => prop.AppUser)
                .WithMany(prop => prop.HouseSales)
                .HasForeignKey(prop => prop.AppUserId);
            builder
                .Property(prop => prop.IsActive)
                .IsRequired();
            builder
                .HasMany(prop => prop.Images)
                .WithOne(prop => prop.HouseSale)
                .HasForeignKey(prop => prop.HouseSaleId);
            builder
                .Property(prop => prop.Address)
                .IsRequired();
            builder
                .Property(prop => prop.HouseArea)
                .IsRequired();
            builder
                .Property(prop => prop.HouseLiveArea)
                .IsRequired();
            builder
                .Property(prop => prop.KitchenArea)
                .IsRequired();
            builder
                .Property(prop => prop.HousePlotArea)
                .IsRequired();
            builder
                .Property(prop => prop.Heating)
                .IsRequired();
            builder
                .Property(prop => prop.Water)
                .IsRequired();
            builder
                .Property(prop => prop.Gas)
                .IsRequired();
            builder
                .Property(prop => prop.Sewage)
                .IsRequired();
            builder
                .Property(prop => prop.Electricity)
                .IsRequired();
            builder
                .Property(prop => prop.Bathhouse)
                .IsRequired();
            builder
                .Property(prop => prop.Garage)
                .IsRequired();
            builder
                .Property(prop => prop.Price)
                .HasColumnType("money")
                .IsRequired();
            builder
                .Property(prop => prop.Phone)
                .IsRequired();
            builder
                .Property(prop => prop.Description)
                .IsRequired();
            builder
                .HasOne(prop => prop.City)
                .WithMany(prop => prop.HouseSales)
                .HasForeignKey(prop => prop.CityId);
        }
    }
}
