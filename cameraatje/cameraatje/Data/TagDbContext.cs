using cameraatje.Contracts;
using cameraatje.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace cameraatje.Data
{
   public class TagDbContext : DbContext, ITagDbContext
    {
        private string connectionString;

        public TagDbContext(string connectionString)
        {
            this.connectionString = connectionString;

            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

    }
}
