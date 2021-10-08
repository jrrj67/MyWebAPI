using System;
using FluentValidation;
using MyWebAPI.Data.Validators;

namespace MyWebAPI.Data.Requests
{
    public class AnimeRequest
    {
        private readonly AnimeRequestValidator _validator = new AnimeRequestValidator();
        public string Name { get; set; }
        public string Description { get; set; }
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
