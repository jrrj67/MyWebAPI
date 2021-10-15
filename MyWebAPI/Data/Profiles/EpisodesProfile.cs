using AutoMapper;
using MyWebAPI.Data.Models;
using MyWebAPI.Data.Requests;
using MyWebAPI.Data.Responses;
using System.Linq;

namespace MyWebAPI.Data.Profiles
{
    public class EpisodesProfile : Profile
    {
        public EpisodesProfile()
        {
            CreateMap<EpisodeRequest, Episode>();
         
            CreateMap<Episode, EpisodeResponse>()
                .ForMember(e => e.Anime, opts => opts
                .MapFrom(e => new { e.Anime.Id, e.Anime.Name, e.Anime.Description, e.Anime.LaunchDate }));
        }
    }
}
