using AutoMapper;
using MyWebAPI.Data.Models;
using MyWebAPI.Data.Requests;
using MyWebAPI.Data.Responses;
using System.Linq;

namespace MyWebAPI.Data.Configs
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            Anime();
            Episode();
        }
        
        private void Anime()
        {
            CreateMap<AnimeRequest, Anime>();
            CreateMap<Anime, AnimeResponse>()
                .ForMember(a => a.Episodes, opts => opts
                .MapFrom(a => a.Episodes.Select(e => new { e.Id, e.Name, e.Description })));
        }
        
        private void Episode()
        {
            CreateMap<EpisodeRequest, Episode>();
            CreateMap<Episode, EpisodeResponse>()
                .ForMember(e => e.Anime, opts => opts
                .MapFrom(e => new { e.Id, e.Name, e.Description, e.LaunchDate }));
        }
    }
}