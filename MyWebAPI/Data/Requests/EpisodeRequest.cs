﻿using System;
using FluentValidation;
using MyWebAPI.Data.Validators;

namespace MyWebAPI.Data.Requests
{
    public class EpisodeRequest
    {
        private readonly EpisodeValidator _validator = new EpisodeValidator();
        public int AnimeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public int Season { get; set; }
        public DateTime LaunchDate { get; set; }

        public void Validate()
        {
            var validationResult = _validator.Validate(this);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString(), validationResult.Errors);
            }
        }
    }
}
