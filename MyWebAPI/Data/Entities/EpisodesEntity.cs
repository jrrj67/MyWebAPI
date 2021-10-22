using Microsoft.EntityFrameworkCore;
using MyWebAPI.Data.Models;
using System;

namespace MyWebAPI.Data.Entities
{
    public class EpisodesEntity : Episode
    {
        public virtual AnimesEntity Anime { get; set; }

        public EpisodesEntity(string name, string description, int number, int season, DateTime launchDate)
        {
            Name = name;
            Description = description;
            Number = number;
            Season = season;
            LaunchDate = launchDate;
        }
        
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EpisodesEntity>().Property(nameof(Name)).IsRequired();

            modelBuilder.Entity<EpisodesEntity>().Property(nameof(Description)).IsRequired();

            modelBuilder.Entity<EpisodesEntity>().Property(nameof(Number)).IsRequired();

            modelBuilder.Entity<EpisodesEntity>().Property(nameof(Season)).IsRequired();

            modelBuilder.Entity<EpisodesEntity>().Property(nameof(LaunchDate)).IsRequired();

            // Relationships
            modelBuilder.Entity<EpisodesEntity>().HasOne(e => e.Anime).WithMany(a => a.Episodes);
        }
    }
}
