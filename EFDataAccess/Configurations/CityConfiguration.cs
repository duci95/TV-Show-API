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
            builder.Property(c => c.CityName).IsRequired();
            builder.HasIndex(c => c.CityName).IsUnique();

            builder.Property(c => c.Deleted).HasDefaultValue(false);
            builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
