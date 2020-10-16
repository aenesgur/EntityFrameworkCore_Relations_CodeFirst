using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreRelations.Data.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string Abbreviation { get; set; }

        public Coach Coach { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<Player> Players { get; set; }
        public virtual ICollection<TeamLeague> TeamLeagues { get; set; }
    }

    public class TeamEntityConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(x => x.TeamName).HasColumnType("nvarchar(50)");
            builder.Property(x => x.Abbreviation).HasColumnType("nvarchar(7)");

            builder.HasOne(x => x.Coach)
                   .WithOne(x => x.Team)
                   .HasForeignKey<Coach>(x => x.TeamId);

            builder.HasOne(x => x.Country)
                   .WithMany(x => x.Teams)
                   .HasForeignKey(x => x.CountryId);
        }
    }
}