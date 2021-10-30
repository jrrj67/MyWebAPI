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
    public abstract class AnimesDI
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IValidator<AnimesRequest>, AnimesValidator>();

            services.AddTransient<IBaseRepository<AnimesEntity>, BaseRepository<AnimesEntity>>();

            services.AddTransient<IBaseService<AnimesResponse, AnimesRequest>, AnimesService>();
        }
    }
}
