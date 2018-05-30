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
        public DbSet<Corner> Corner { get; set; }
        public DbSet<Toddler> Toddler { get ; set; }
        public DbSet<User> User { get ; set ; }
        public DbSet<Picture> Picture { get ; set ; }
        public DbSet<Tag> Tag { get ; set; }
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
