using Microsoft.EntityFrameworkCore;
using MyWebAPI.Data.Models;

namespace MyWebAPI.Data.Entities
{
    public class UsersEntity : User
    {
        public RolesEntity Role { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersEntity>().HasKey(t => t.Id);

            modelBuilder.Entity<UsersEntity>().Property(e => e.Name).IsRequired();

            modelBuilder.Entity<UsersEntity>().Property(e => e.Email).IsRequired();

            modelBuilder.Entity<UsersEntity>().Property(e => e.Password).IsRequired();

            modelBuilder.Entity<UsersEntity>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);
        }
    }
}
