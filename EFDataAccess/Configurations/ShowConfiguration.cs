using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class ShowConfiguration : IEntityTypeConfiguration<Show>
    {
        public void Configure(EntityTypeBuilder<Show> builder)
        {
            builder.Property(s => s.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(s => s.Deleted).HasDefaultValue(false);                                   

            builder.Property(s => s.ShowPicturePath).HasMaxLength(150);
            builder.Property(s => s.ShowPicturePath).IsRequired();
            builder.Property(s => s.ShowText).IsRequired();
            builder.Property(s => s.ShowText).HasMaxLength(800);
            builder.Property(s => s.ShowTitle).HasMaxLength(100);
            builder.Property(s => s.ShowTitle).IsRequired();

            builder.HasIndex(s => s.ShowPicturePath).IsUnique();
            builder.HasIndex(s => s.ShowTitle).IsUnique();

            builder.Property(s => s.ShowYear).IsRequired();
        }
    }
}
