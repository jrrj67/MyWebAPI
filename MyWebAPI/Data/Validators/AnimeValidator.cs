﻿using System;
using FluentValidation;
using MyWebAPI.Data.Models;
using MyWebAPI.Data.Requests;

namespace MyWebAPI.Data.Validators
{
    public class AnimeValidator : AbstractValidator<AnimeRequest>
    {
        public AnimeValidator()
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
