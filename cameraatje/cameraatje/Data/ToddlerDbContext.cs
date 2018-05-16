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
        public DbSet<Toddler> Toddlers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private string connectionString;

        public ToddlerDbContext(string connectionString)
        {
            this.connectionString = connectionString;

            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
