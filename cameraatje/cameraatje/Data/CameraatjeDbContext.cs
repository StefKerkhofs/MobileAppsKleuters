using System;
using System.Collections.Generic;
using System.Text;
using cameraatje.Models;
using cameraatje.Contracts;
using Microsoft.EntityFrameworkCore;
namespace cameraatje.Data
{
    public class CameraatjeDbContext : DbContext, IDbContext
    {
        public DbSet<Corner> Corners { get; set; }
        public DbSet<Toddler> Toddlers { get ; set; }
        public DbSet<User> Users { get ; set ; }
        public DbSet<Picture> Pictures { get ; set ; }
        public DbSet<Tag> Tags { get ; set; }
        private string connection;

        public CameraatjeDbContext(string connectionString) {
            this.connection = connectionString;

            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connection);
            }
        }
    }
}
