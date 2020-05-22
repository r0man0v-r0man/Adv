using System;
using System.Collections.Generic;
using System.Text;
using Adv.DAL.Entities.Adverts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adv.DAL.EntitiesConfigurations
{
    public class FlatSaleConfiguration : IEntityTypeConfiguration<FlatSale>
    {
        public void Configure(EntityTypeBuilder<FlatSale> builder)
        {
            builder
                .Property(prop => prop.Id)
                .IsRequired();
            builder
                .HasOne(prop => prop.AppUser)
                .WithMany(prop => prop.FlatSales)
                .HasForeignKey(prop => prop.AppUserId);
            builder
                .Property(prop => prop.IsActive)
                .IsRequired();
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
                .Property(prop => prop.FlatArea)
                .IsRequired();
            builder
                .Property(prop => prop.FlatLiveArea)
                .IsRequired();
            builder
                .Property(prop => prop.KitchenArea)
                .IsRequired();
            builder
                .Property(prop => prop.Balcony)
                .IsRequired();
            builder
                .Property(prop => prop.Toilet)
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
        }
    }
}
