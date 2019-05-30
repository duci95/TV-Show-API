using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(l => l.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(l => l.Deleted).HasDefaultValue(false);

            builder.Property(l => l.CategoryTitle).HasMaxLength(30);
            
            builder.HasIndex(l => l.CategoryTitle).IsUnique();
            
            builder.Property(l => l.CategoryTitle).IsRequired();
            
           
        }
    }
}
