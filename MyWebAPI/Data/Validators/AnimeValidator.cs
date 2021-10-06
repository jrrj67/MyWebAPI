using System;
using FluentValidation;
using MyWebAPI.Data.Models;

namespace MyWebAPI.Data.Validators
{
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
            
            RuleFor(anime => anime.LaunchDate)
                .NotNull()
                .LessThanOrEqualTo(DateTime.UtcNow);
        }
    }
}
