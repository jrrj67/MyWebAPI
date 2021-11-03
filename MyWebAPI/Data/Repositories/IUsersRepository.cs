using MyWebAPI.Data.Entities;

namespace MyWebAPI.Data.Repositories
{
    public interface IUsersRepository : IBaseRepository<UsersEntity>
    {
        bool IsUniqueEmail(string email);
    }
}