using Adv.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.DAL.EntitiesConfigurations
{
    public class FlatConfiguration : IEntityTypeConfiguration<Flat>
    {
        public void Configure(EntityTypeBuilder<Flat> builder)
        {
            builder
                .Property(prop => prop.Description)
                .IsRequired();
            builder
                .Property(prop => prop.Created)
                .IsRequired();
            builder
                .Property(prop => prop.City)
                .IsRequired();
            builder
                .Property(prop => prop.Price)
                .IsRequired();
            builder
                .Property(prop => prop.Images)
                .IsRequired();
            builder
                .Property(prop => prop.IsActive)
                .IsRequired();
            builder
                .Property(prop => prop.Address)
                .IsRequired();
            //builder
            //    .HasOne(prop => prop.AppUser)
            //    .WithMany(prop => prop.Flats)
            //    .HasForeignKey(prop => prop.AppUserId);
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
                .Property(prop => prop.Duration)
                .IsRequired();
            builder
                .Property(prop => prop.Floor)
                .IsRequired();
            builder
                .Property(prop => prop.Phone)
                .IsRequired();
        }
    }
}
