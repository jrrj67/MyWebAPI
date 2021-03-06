using FluentValidation;
using MyWebAPI.Data.Requests;
using MyWebAPI.Data.Responses;
using MyWebAPI.Data.Services;

namespace MyWebAPI.Data.Validators
{
    public class UsersValidator : AbstractValidator<UsersRequest>
    {
        private readonly IUsersService<UsersResponse, UsersRequest> _usersService;

        public UsersValidator(IUsersService<UsersResponse, UsersRequest> usersService)
        {
            _usersService = usersService;            

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
                .MaximumLength(100)
                .Must(email => _usersService.IsUniqueEmail(email))
                .WithMessage("Email already exists.");

            RuleFor(field => field.RoleId)
                .NotNull();
        }
    }
}
