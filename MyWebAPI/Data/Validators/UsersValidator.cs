using FluentValidation;
using MyWebAPI.Data.Requests;

namespace MyWebAPI.Data.Validators
{
    public class UsersValidator : AbstractValidator<UsersRequest>
    {
        public UsersValidator()
        {
            RuleFor(field => field.Name)
                .MinimumLength(2)
                .MaximumLength(200)
                .NotNull();

            RuleFor(field => field.Password)
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(50);

            RuleFor(field => field.Email)
                .EmailAddress()
                .NotNull()
                .MaximumLength(100);

            RuleFor(field => field.RoleId)
                .NotNull();
        }
    }
}
