﻿using Microsoft.EntityFrameworkCore;
using MyWebAPI.Data.Models;

namespace MyWebAPI.Data.Entities
{
    public class UsersEntity : User
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersEntity>().HasKey(t => t.Id);

            modelBuilder.Entity<UsersEntity>().Property(e => e.Name).IsRequired();

            modelBuilder.Entity<UsersEntity>().Property(e => e.Email).IsRequired();

            modelBuilder.Entity<UsersEntity>().Property(e => e.Password).IsRequired();
        }
    }
}