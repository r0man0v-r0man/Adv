using System;
using System.Collections.Generic;
using System.Text;
using Adv.DAL.Entities.Images;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adv.DAL.EntitiesConfigurations
{
    public class ImageConfiguration: IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder
                .HasOne(prop => prop.BaseAdvert)
                .WithMany(prop => prop.Images);

        }
    }
}
