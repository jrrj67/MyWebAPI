using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MyWebAPI.Data.Repositories;
using MyWebAPI.Data.Requests;
using MyWebAPI.Data.Responses;
using MyWebAPI.Data.Services;
using MyWebAPI.Data.Validators;

namespace MyWebAPI.Data.DependecyInjections
{
    public abstract class UsersDI
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IValidator<UsersRequest>, UsersValidator>();

            services.AddTransient<IUsersRepository, UsersRepository>();

            services.AddTransient<IUsersService<UsersResponse, UsersRequest>, UsersService>();
        }
    }
}
