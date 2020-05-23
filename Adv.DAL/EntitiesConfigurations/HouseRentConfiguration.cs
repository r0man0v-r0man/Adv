using System;
using System.Collections.Generic;
using System.Text;
using Adv.DAL.Entities.Adverts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adv.DAL.EntitiesConfigurations
{
    public class HouseRentConfiguration : IEntityTypeConfiguration<HouseRent>
    {
        public void Configure(EntityTypeBuilder<HouseRent> builder)
        {
            builder
                .Property(prop => prop.Id)
                .IsRequired();
            builder
                .HasOne(prop => prop.AppUser)
                .WithMany(prop => prop.HouseRents)
                .HasForeignKey(prop => prop.AppUserId);
            builder
                .Property(prop => prop.IsActive)
                .IsRequired();
            builder
                .HasMany(prop => prop.Images)
                .WithOne(prop => prop.HouseRent)
                .HasForeignKey(prop => prop.HouseRentId);
            builder
                .Property(prop => prop.Address)
                .IsRequired();
            builder
                .Property(prop => prop.Rooms)
                .IsRequired();
            builder
                .Property(prop => prop.Furniture)
                .IsRequired();
            builder
                .Property(prop => prop.Refrigerator)
                .IsRequired();
            builder
                .Property(prop => prop.MicrowaveOven)
                .IsRequired();
            builder
                .Property(prop => prop.Internet)
                .IsRequired();
            builder
                .Property(prop => prop.WashingMachine)
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
                .Property(prop => prop.Duration)
                .IsRequired();
            builder
                .Property(prop => prop.Phone)
                .IsRequired();
            builder
                .Property(prop => prop.Description)
                .IsRequired();
        }
    }
}
