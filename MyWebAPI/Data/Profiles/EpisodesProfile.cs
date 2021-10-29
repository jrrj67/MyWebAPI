using AutoMapper;
using MyWebAPI.Data.Entities;
using MyWebAPI.Data.Requests;
using MyWebAPI.Data.Responses;

namespace MyWebAPI.Data.Profiles
{
    public class EpisodesProfile : Profile
    {
        public EpisodesProfile()
        {
            CreateMap<EpisodesRequest, EpisodesEntity>();

            CreateMap<EpisodesEntity, EpisodesResponse>()
                .ForMember(e => e.Anime, opts => opts
                .MapFrom(e => new { e.Anime.Id, e.Anime.Name, e.Anime.Description, e.Anime.LaunchDate }));
        }
    }
}
