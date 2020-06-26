using System;
using System.Collections.Generic;
using System.Text;
using Adv.DAL.Entities.Adverts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adv.DAL.EntitiesConfigurations
{
    public class FlatRentConfiguration : IEntityTypeConfiguration<FlatRent>
    {
        public void Configure(EntityTypeBuilder<FlatRent> builder)
        {
            builder
                .Property(prop => prop.Id)
                .IsRequired();
            builder
                .HasOne(prop => prop.AppUser)
                .WithMany(prop => prop.FlatRents)
                .HasForeignKey(prop => prop.AppUserId);
            builder
                .Property(prop => prop.IsActive)
                .IsRequired();
            builder
                .HasMany(prop => prop.Images)
                .WithOne(prop => prop.FlatRent)
                .HasForeignKey(prop => prop.FlatRentId);
            builder
                .Property(prop => prop.Address)
                .IsRequired();
            builder
                .Property(prop => prop.Floor)
                .IsRequired();
            builder
                .Property(prop => prop.AllFloor)
                .IsRequired();
            builder
                .Property(prop => prop.Rooms)
                .IsRequired();
            builder
                .Property(prop => prop.Balcony)
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
