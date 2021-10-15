using AutoMapper;
using MyWebAPI.Data.Models;
using MyWebAPI.Data.Requests;
using MyWebAPI.Data.Responses;
using System.Linq;

namespace MyWebAPI.Data.Profiles
{
    public class AnimesProfile : Profile
    {
        public AnimesProfile()
        {
            CreateMap<AnimeRequest, Anime>();

            CreateMap<Anime, AnimeResponse>()
                .ForMember(a => a.Episodes, opts => opts
                .MapFrom(a => a.Episodes.Select(e => new { e.Id, e.Name, e.Description })));
        }
    }
}
