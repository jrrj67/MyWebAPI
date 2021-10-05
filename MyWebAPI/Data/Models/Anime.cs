using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;

namespace MyWebAPI.Data.Models
{
    public class Anime : BaseEntity<Anime>
    {
        private readonly AnimeValidator _validator = new AnimeValidator();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime LaunchDate { get; private set; }
        
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

        public override void Update(Anime anime)
        {
            var validatorResult = _validator.Validate(anime);

            if (!validatorResult.IsValid)
            {
                throw new ValidationException("Validation errors.", validatorResult.Errors);    
            }

            Name = anime.Name;
            Description = anime.Description;
            LaunchDate = anime.LaunchDate;
        }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anime>().Property(nameof(Name)).IsRequired();
            modelBuilder.Entity<Anime>().Property(nameof(Description)).IsRequired();
        }
    }

    public class AnimeValidator : AbstractValidator<Anime>
    {
        public AnimeValidator()
        {
            RuleFor(anime => anime.Name)
                .NotNull()
                .MaximumLength(100);

            RuleFor(anime => anime.Description)
                .NotNull()
                .MaximumLength(100);
            
            RuleFor(anime => anime.LaunchDate).LessThanOrEqualTo(DateTime.UtcNow);
        }
    }
}
