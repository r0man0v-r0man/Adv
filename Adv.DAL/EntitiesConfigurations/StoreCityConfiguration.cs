using Adv.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adv.DAL.EntitiesConfigurations
{
    public class StoreCityConfiguration : IEntityTypeConfiguration<StoreCity>
    {
        public void Configure(EntityTypeBuilder<StoreCity> builder)
        {
            builder?
                .Property(prop => prop.Id)
                .IsRequired();
            builder?
                .Property(prop => prop.Name)
                .IsRequired();
        }
    }
}