using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(a => a.ActorFirstName).HasMaxLength(30);
            builder.Property(a => a.ActorFirstName).IsRequired();

            builder.Property(a => a.ActorLastName).HasMaxLength(40);
            builder.Property(a => a.ActorLastName).IsRequired();

            builder.Property(a => a.Deleted).HasDefaultValue(false);
            builder.Property(a => a.CreatedAt).HasDefaultValueSql("GETDATE()");
                       
        }
    }
}
