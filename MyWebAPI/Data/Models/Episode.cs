using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.Data.Validators;
using System;
using System.Text.Json.Serialization;

namespace MyWebAPI.Data.Models
{
    public class Episode : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public int Season { get; set; }
        public DateTime LaunchDate { get; set; }
        public int AnimeId { get; set; }

        // Navigation property
        public Anime Anime { get; set; }

        public Episode(string name, string description, int number, int season, DateTime launchDate)
        {
            Name = name;
            Description = description;
            Number = number;
            Season = season;
            LaunchDate = launchDate;
        }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Episode>().Property(nameof(Name)).IsRequired();
            modelBuilder.Entity<Episode>().HasIndex(e => e.Name).IsUnique();

            modelBuilder.Entity<Episode>().Property(nameof(Description)).IsRequired();

            modelBuilder.Entity<Episode>().Property(nameof(Number)).IsRequired();
            modelBuilder.Entity<Episode>().HasIndex(e => e.Number).IsUnique();
            
            modelBuilder.Entity<Episode>().Property(nameof(Season)).IsRequired();
            
            modelBuilder.Entity<Episode>().Property(nameof(LaunchDate)).IsRequired();

            // Relationships
            modelBuilder.Entity<Episode>().HasOne(e => e.Anime).WithMany(a => a.Episodes);
        }
    }
}
