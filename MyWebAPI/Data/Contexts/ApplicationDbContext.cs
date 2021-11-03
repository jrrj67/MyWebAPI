using Microsoft.EntityFrameworkCore;
using MyWebAPI.Data.Entities;
using MyWebAPI.Data.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyWebAPI.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AnimesEntity> Animes { get; set; }
        public DbSet<EpisodesEntity> Episodes { get; set; }
        public DbSet<UsersEntity> Users { get; set; }
        public DbSet<RolesEntity> Roles { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UsersEntity.OnModelCreating(modelBuilder);
            AnimesEntity.OnModelCreating(modelBuilder);
            EpisodesEntity.OnModelCreating(modelBuilder);
            RolesEntity.OnModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        // Logic implemented to add created at and updated at

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            AddTimestamps();
            return base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseModel && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow; // current datetime

                if (entity.State == EntityState.Added)
                {
                    ((BaseModel)entity.Entity).CreatedAt = now;
                }

                ((BaseModel)entity.Entity).UpdatedAt = now;
            }
        }
    }
}