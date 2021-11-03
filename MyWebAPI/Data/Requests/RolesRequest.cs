using FluentValidation;
using MyWebAPI.Data.Validators;

namespace MyWebAPI.Data.Requests
{
    public class RolesRequest
    {
        private readonly RolesValidator _validator = new RolesValidator();

        public string Name { get; set; }

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
