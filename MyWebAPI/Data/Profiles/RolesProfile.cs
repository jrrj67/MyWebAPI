using AutoMapper;
using MyWebAPI.Data.Entities;
using MyWebAPI.Data.Requests;
using MyWebAPI.Data.Responses;

namespace MyWebAPI.Data.Profiles
{
    public class RolesProfile : Profile
    {
        public RolesProfile()
        {
            CreateMap<RolesRequest, RolesEntity>();

            CreateMap<RolesEntity, RolesResponse>();
        }
    }
}
