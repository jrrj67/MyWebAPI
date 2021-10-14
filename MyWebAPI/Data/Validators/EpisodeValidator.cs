using System;
using FluentValidation;
using MyWebAPI.Data.Models;
using MyWebAPI.Data.Requests;

namespace MyWebAPI.Data.Validators
{
    public class EpisodeValidator : AbstractValidator<EpisodeRequest>
    {
        public EpisodeValidator()
        {
            RuleFor(field => field.AnimeId)
                .NotNull();
            
            RuleFor(field => field.Name)
                .NotNull()
                .MaximumLength(100);

            RuleFor(field => field.Description)
                .NotNull()
                .MaximumLength(500);

            RuleFor(field => field.Number)
                .NotNull();
            
            RuleFor(field => field.Season)
                .NotNull();
            
            RuleFor(field => field.LaunchDate)
                .NotNull()
                .LessThanOrEqualTo(DateTime.UtcNow);
        }
    }
}
