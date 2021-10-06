using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.Data.Validators;
using System;

namespace MyWebAPI.Data.Models
{
    public class Anime : BaseModel
    {
        private readonly AnimeValidator _validator = new AnimeValidator();
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LaunchDate { get; set; }
        
        public Anime(string name, string description, DateTime launchDate)
        {
            Name = name;
            Description = description;
            LaunchDate = launchDate;
        }

        public override ValidationResult Validate()
        {
            return _validator.Validate(this);
        }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anime>().Property(nameof(Name)).IsRequired();
            modelBuilder.Entity<Anime>().Property(nameof(Description)).IsRequired();
        }
    }
}
