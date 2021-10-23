using System;
using FluentValidation;
using MyWebAPI.Data.Validators;

namespace MyWebAPI.Data.Requests
{
    public class UsersRequest
    {
        private readonly UsersValidator _validator = new UsersValidator();

        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

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
