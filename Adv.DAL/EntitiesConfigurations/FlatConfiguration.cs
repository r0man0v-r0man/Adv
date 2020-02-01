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
            builder
                .HasOne(prop => prop.AppUser)
                .WithMany(prop => prop.Flats)
                .HasForeignKey(prop => prop.AppUserId);
        }
    }
}
