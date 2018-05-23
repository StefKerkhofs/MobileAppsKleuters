using cameraatje.Contracts;
using cameraatje.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace cameraatje.Data
{
   public class UserDbContext : DbContext, IUserDbContext
    {
        private string connectionString;

        public UserDbContext(string connectionString)
        {
            this.connectionString = connectionString;

            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
