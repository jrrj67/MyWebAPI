using FluentValidation;
using MyWebAPI.Data.Entities;
using MyWebAPI.Data.Repositories;
using MyWebAPI.Data.Services;
using MyWebAPI.Data.Validators;

namespace MyWebAPI.Data.Requests
{
    public class UsersRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }

        public UsersValidator validator = new UsersValidator();

        public void Validate()
        {
            var validationResult = validator.Validate(this);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString(), validationResult.Errors);
            }
        }
    }
}
