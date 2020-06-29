using Adv.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adv.DAL.EntitiesConfigurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
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
