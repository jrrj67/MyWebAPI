using Microsoft.EntityFrameworkCore;
using MyWebAPI.Data.Config;
using MyWebAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWebAPI.Data.Repositories
{
    public class AnimeRepository : BaseRepository<Anime>
    {
        public AnimeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override List<Anime> GetAll()
        {
            return _context.Set<Anime>()
                .Include(a => a.Episodes)
                .ToList();
        }

        public override Anime GetById(int id)
        {
            var item = _context.Set<Anime>()
                .Include(a => a.Episodes)
                .FirstOrDefault(t => t.Id == id);

            if (item == null)
            {
                throw new ArgumentException("Not found.");
            }

            return item;
        }
    }
}
