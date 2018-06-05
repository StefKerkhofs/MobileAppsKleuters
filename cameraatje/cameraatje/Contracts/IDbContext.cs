using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using cameraatje.Models;
using Microsoft.EntityFrameworkCore;
namespace cameraatje.Contracts

{
    //Author: Sasha van de Voorde
    public interface IDbContext
    {
        DbSet<Corner> Corner { get; set; }
        DbSet<Toddler> Toddler{ get; set; }
        DbSet<User> User { get; set; }
        DbSet<Picture> Picture { get; set; }
        DbSet<Tag> Tag { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
