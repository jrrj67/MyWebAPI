using FluentValidation;
using MyWebAPI.Data.Requests;
using System;

namespace MyWebAPI.Data.Validators
{
    public class EpisodesValidator : AbstractValidator<EpisodesRequest>
    {
        public EpisodesValidator()
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
