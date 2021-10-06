using FluentValidation;
using MyWebAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly ApplicationDbContext context;

        public BaseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            var item = context.Set<T>().FirstOrDefault(t => t.Id == id);

            if (item == null)
            {
                throw new ArgumentException("Not found.");
            }

            return context.Set<T>().FirstOrDefault(t => t.Id == id);
        }

        public async Task SaveAsync(T item)
        {
            item.ResetHiddenFields();

            var validator = item.Validate();

            if (!validator.IsValid)
            {
                throw new ValidationException(validator.ToString(), validator.Errors);
            }

            await context.Set<T>().AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, T item)
        {
            item.ResetHiddenFields();

            var exists = context.Set<T>().Any(t => t.Id == id);

            if (!exists)
            {
                throw new ArgumentException("Not found.");
            }

            var validator = item.Validate();

            if (!validator.IsValid)
            {
                throw new ValidationException(validator.ToString(), validator.Errors);
            }

            context.Set<T>().Update(item);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = context.Set<T>().FirstOrDefault(t => t.Id == id);

            if (item == null)
            {
                throw new ArgumentException("Not found.");
            }

            context.Set<T>().Remove(item);
            await context.SaveChangesAsync();
        }
    }
}
