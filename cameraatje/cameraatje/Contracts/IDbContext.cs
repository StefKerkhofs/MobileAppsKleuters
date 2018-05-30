using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using cameraatje.Models;
using Microsoft.EntityFrameworkCore;
namespace cameraatje.Contracts

{
    public interface IDbContext
    {
        DbSet<Corner> Corners { get; set; }
        DbSet<Toddler> Toddlers{ get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Picture> Pictures { get; set; }
        DbSet<Tag> Tags { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
