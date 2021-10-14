using MyWebAPI.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWebAPI.Data.Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        List<T> GetAll();
        T GetById(int id);
        Task SaveAsync(T item);
        Task UpdateAsync(int id, T item);
        Task Delete(int id);
    }
}