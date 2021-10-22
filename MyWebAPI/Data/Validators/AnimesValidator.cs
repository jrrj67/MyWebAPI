using System;
using FluentValidation;
using MyWebAPI.Data.Requests;

namespace MyWebAPI.Data.Validators
{
    public class AnimesValidator : AbstractValidator<AnimesRequest>
    {
        public AnimesValidator()
        {
            RuleFor(anime => anime.Name)
                .NotNull()
                .MaximumLength(100);

            RuleFor(anime => anime.Description)
                .NotNull()
                .MaximumLength(500);
            
            RuleFor(anime => anime.LaunchDate)
                .NotNull()
                .LessThanOrEqualTo(DateTime.UtcNow);
        }
    }
}
