using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class SponsorConfiguration : IEntityTypeConfiguration<Sponsor>
    {
        public void Configure(EntityTypeBuilder<Sponsor> builder)
        {
            builder.Property(s => s.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(s => s.Deleted).HasDefaultValue(false);

            builder.Property(s => s.SponsorPicturePath).IsRequired();
            builder.Property(s => s.SponsorPicturePath).HasMaxLength(120);
            builder.Property(s => s.SponsorURL).HasMaxLength(70);
            builder.Property(s => s.SponsorURL).IsRequired();

            builder.HasIndex(s => s.SponsorURL).IsUnique();
        }
    }
}
