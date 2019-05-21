using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class ActorShowConfiguration : IEntityTypeConfiguration<ActorShow>
    {
        public void Configure(EntityTypeBuilder<ActorShow> builder)
        {
            builder.HasKey(ash => new { ash.ActorId, ash.ShowId });
        }
    }
}
