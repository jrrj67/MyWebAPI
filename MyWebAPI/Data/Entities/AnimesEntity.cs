using Microsoft.EntityFrameworkCore;
using MyWebAPI.Data.Models;
using System;
using System.Collections.Generic;

namespace MyWebAPI.Data.Entities
{
    public class AnimesEntity : Anime
    {
        public virtual List<EpisodesEntity> Episodes { get; set; }

        public AnimesEntity(string name, string description, DateTime launchDate)
        {
            Name = name;
            Description = description;
            LaunchDate = launchDate;
        }
        
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimesEntity>().Property(nameof(Name)).IsRequired();

            modelBuilder.Entity<AnimesEntity>().Property(nameof(Description)).IsRequired();

            modelBuilder.Entity<AnimesEntity>().Property(nameof(LaunchDate)).IsRequired();
        }
    }
}
