using MyWebAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MyWebAPI.Data.Entities
{
    public class RolesEntity : Role
    {
        public ICollection<UsersEntity> Users { get; set; }
        
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolesEntity>().HasKey(t => t.Id);

            modelBuilder.Entity<RolesEntity>().Property(e => e.Name).IsRequired();
        }
    }
}
