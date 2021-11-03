using MyWebAPI.Data.Contexts;
using MyWebAPI.Data.Entities;
using System.Linq;

namespace MyWebAPI.Data.Repositories
{
    public class UsersRepository : BaseRepository<UsersEntity>, IUsersRepository
    {
        public UsersRepository(ApplicationDbContext context) : base(context)
        {
        }

        public bool IsUniqueEmail(string email)
        {
            return !_context.Set<UsersEntity>().Where(u => u.Email == email).Any();
        }
    }
}
