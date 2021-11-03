using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MyWebAPI.Data.Entities;
using MyWebAPI.Data.Repositories;
using MyWebAPI.Data.Requests;
using MyWebAPI.Data.Responses;
using MyWebAPI.Data.Services;
using MyWebAPI.Data.Validators;

namespace MyWebAPI.Data.DependecyInjections
{
    public abstract class RolesDI
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IValidator<RolesRequest>, RolesValidator>();

            services.AddTransient<IBaseRepository<RolesEntity>, BaseRepository<RolesEntity>>();

            services.AddTransient<IBaseService<RolesResponse, RolesRequest>, RolesService>();
        }
    }
}
