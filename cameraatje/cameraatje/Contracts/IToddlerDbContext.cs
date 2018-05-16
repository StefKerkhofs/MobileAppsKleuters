using System;
using System.Collections.Generic;
using System.Text;
using cameraatje.Models;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace cameraatje.Contracts
{
    public interface IToddlerDbContext
    {
        DbSet<Toddler> Toddlers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
