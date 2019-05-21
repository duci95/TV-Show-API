using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(r => r.RoleName).IsRequired();
            builder.Property(r => r.RoleName).HasMaxLength(20);
            builder.HasIndex(r => r.RoleName).IsUnique();

            builder.Property(r => r.Deleted).HasDefaultValue(false);
            builder.Property(r => r.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
