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
            builder.HasMany(a => a.ActorShows)
                    .WithOne(a => a.Actor)
                    .HasForeignKey(a => a.ActorId)
                    .OnDelete(DeleteBehavior.SetNull);
            


        }
    }
}
