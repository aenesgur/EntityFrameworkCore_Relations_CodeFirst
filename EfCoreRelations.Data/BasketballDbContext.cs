using EfCoreRelations.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreRelations.Data
{
    public class BasketballDbContext : DbContext
    {
        public BasketballDbContext(DbContextOptions<BasketballDbContext> options) : base(options)
        { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Coach> Coachs { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<TeamLeague> TeamLeagues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeamEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CoachEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TeamLeagueEntityConfiguration());
        }
    }
}
