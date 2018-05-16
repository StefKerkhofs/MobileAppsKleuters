using System;
using System.Collections.Generic;
using System.Text;
using cameraatje.Contracts;
using cameraatje.Models;
using Microsoft.EntityFrameworkCore;

namespace cameraatje.Data
{
    public class ToddlerDbContext : DbContext, IToddlerDbContext
    {

        private string connectionString;

        public ToddlerDbContext(string connectionString)
        {
            this.connectionString = connectionString;

            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Toddler> Toddlers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
