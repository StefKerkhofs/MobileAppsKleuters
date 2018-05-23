using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using cameraatje.Contracts;
using cameraatje.Models;
using Microsoft.EntityFrameworkCore;
namespace cameraatje.Data
{
    public class CornerDbContext : DbContext, ICornerDbContext
    {
        private string connectionString;

        public CornerDbContext(string connectionString)
        {
            this.connectionString = connectionString;
            Database.EnsureCreated();
        }
        public DbSet<Corner> Corners { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
