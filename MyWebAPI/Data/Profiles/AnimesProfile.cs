using AutoMapper;
using MyWebAPI.Data.Entities;
using MyWebAPI.Data.Requests;
using MyWebAPI.Data.Responses;
using System.Linq;

namespace MyWebAPI.Data.Profiles
{
    public class AnimesProfile : Profile
    {
        public AnimesProfile()
        {
            CreateMap<AnimesRequest, AnimesEntity>();

            CreateMap<AnimesEntity, AnimesResponse>()
                .ForMember(a => a.Episodes, opts => opts
                .MapFrom(a => a.Episodes.Select(e => new { e.Id, e.Name, e.Description })));
        }
    }
}
