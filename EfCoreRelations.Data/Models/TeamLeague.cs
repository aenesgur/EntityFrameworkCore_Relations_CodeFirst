using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreRelations.Data.Models
{
    public class TeamLeague
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int LeagueId { get; set; }
        public League League { get; set; }
    }

    public class TeamLeagueEntityConfiguration : IEntityTypeConfiguration<TeamLeague>
    {
        public void Configure(EntityTypeBuilder<TeamLeague> builder)
        {
            builder.HasKey(x => new { x.TeamId, x.LeagueId });

            builder.HasOne<Team>(x => x.Team)
                   .WithMany(x => x.TeamLeagues)
                   .HasForeignKey(x => x.TeamId);

            builder.HasOne<League>(x => x.League)
                   .WithMany(x => x.TeamLeagues)
                   .HasForeignKey(x => x.LeagueId);
        }
    }
}
