using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {            
            

            builder.Property(c => c.CommentText).IsRequired();
            builder.Property(c => c.CommentText).HasMaxLength(150);

            builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(c => c.Deleted).HasDefaultValue(false);

        }
    }
}
