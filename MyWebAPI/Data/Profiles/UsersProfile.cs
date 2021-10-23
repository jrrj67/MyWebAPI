using AutoMapper;
using MyWebAPI.Data.Entities;
using MyWebAPI.Data.Requests;
using MyWebAPI.Data.Responses;

namespace MyWebAPI.Data.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<UsersRequest, UsersEntity>();

            CreateMap<UsersEntity, UsersResponse>();
        }
    }
}
