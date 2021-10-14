using AutoMapper;
using MyWebAPI.Data.Models;
using MyWebAPI.Data.Requests;
using MyWebAPI.Data.Responses;
using System.Collections.Generic;

namespace MyWebAPI.Data.Config
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
            CreateMap<Anime, AnimeResponse>();
        }
        
        private void Episode()
        {
            CreateMap<EpisodeRequest, Episode>();
            CreateMap<Episode, EpisodeResponse>();
        }
    }
}