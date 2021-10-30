using MyWebAPI.Data.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWebAPI.Data.Services
{
    public interface IUsersService<UsersResponse, UsersRequest> : IBaseService<UsersResponse, UsersRequest>
    {
       LoginResponse Login(UsersRequest userRequest);
    }
}