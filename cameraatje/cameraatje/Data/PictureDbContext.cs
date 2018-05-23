using cameraatje.Contracts;
using cameraatje.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace cameraatje.Data
{
   public class PictureDbContext : DbContext, IPictureDbContext
    {

        private string connectionString;

        public PictureDbContext(string connectionString)
        {
            this.connectionString = connectionString;

            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Picture> Pictures { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
