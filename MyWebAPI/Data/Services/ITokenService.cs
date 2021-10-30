using Microsoft.Extensions.Configuration;
using MyWebAPI.Data.Entities;

namespace MyWebAPI.Data.Services
{
    public interface ITokenService
    {
        IConfiguration Configuration { get; }

        string GenerateToken(UsersEntity userEntity);
    }
}