using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class ShowVoteConfiguration : IEntityTypeConfiguration<ShowVote>
    {
        public void Configure(EntityTypeBuilder<ShowVote> builder)
        {
            builder.HasKey(sv => new { sv.ShowId, sv.UserId });
        }
    }
}
