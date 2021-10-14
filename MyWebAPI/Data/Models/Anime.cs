using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.Data.Validators;
using System;
using System.Collections.Generic;

namespace MyWebAPI.Data.Models
{
    public class Anime : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LaunchDate { get; set; }

        // Navigation property
        public List<Episode> Episodes { get; set; }

        public Anime(string name, string description, DateTime launchDate)
        {
            Name = name;
            Description = description;
            LaunchDate = launchDate;
        }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anime>().Property(nameof(Name)).IsRequired();
            modelBuilder.Entity<Anime>().HasIndex(e => e.Name).IsUnique();

            modelBuilder.Entity<Anime>().Property(nameof(Description)).IsRequired();
            
            modelBuilder.Entity<Anime>().Property(nameof(LaunchDate)).IsRequired();
        }
    }
}
