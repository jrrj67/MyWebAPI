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
    public abstract class EpisodesDI
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IValidator<EpisodesRequest>, EpisodesValidator>();

            services.AddTransient<IBaseRepository<EpisodesEntity>, BaseRepository<EpisodesEntity>>();

            services.AddTransient<IBaseService<EpisodesResponse, EpisodesRequest>, EpisodesService>();
        }
    }
}
