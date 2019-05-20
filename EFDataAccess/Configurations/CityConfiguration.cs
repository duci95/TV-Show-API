using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasMany(c => c.Users)
                   .WithOne(c => c.City)
                   .HasForeignKey(c => c.CityId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasIndex(c => c.CityName).IsUnique();
        }
    }
}
