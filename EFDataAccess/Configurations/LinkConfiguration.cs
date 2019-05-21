using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class LinkConfiguration : IEntityTypeConfiguration<Link>
    {
        public void Configure(EntityTypeBuilder<Link> builder)
        {
            builder.Property(l => l.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(l => l.Deleted).HasDefaultValue(false);

            builder.Property(l => l.LinkTitle).HasMaxLength(30);
            builder.Property(l => l.Path).HasMaxLength(30);

            builder.HasIndex(l => l.LinkTitle).IsUnique();
            builder.HasIndex(l => l.Path).IsUnique();

            builder.Property(l => l.LinkTitle).IsRequired();
            builder.Property(l => l.Path).IsRequired();
            builder.Property(l => l.Parent).IsRequired();
        }
    }
}
