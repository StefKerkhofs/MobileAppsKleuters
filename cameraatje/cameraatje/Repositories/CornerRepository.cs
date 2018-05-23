using cameraatje.Contracts;
using cameraatje.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cameraatje.Repositories
{
    public class CornerRepository : ICornerRepository
    {
        private ICornerDbContext dbContext;

        public CornerRepository(ICornerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Corner>> GetItemsAsync()
        {
            return await dbContext.Corners.ToListAsync();
        }

        public async Task<Corner> GetItemAsync(int id)
        {
            return await dbContext.Corners.SingleAsync(corner => corner.hoek_id == id);
        }

        public async Task<int> SaveItemAsync(Corner corner)
        {
            if (corner.hoek_id == 0)
            {
                await dbContext.Corners.AddAsync(corner);
            }

            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteItemAsync(Corner corner)
        {
            dbContext.Corners.Remove(corner);

            return await dbContext.SaveChangesAsync();
        }
    }
}
