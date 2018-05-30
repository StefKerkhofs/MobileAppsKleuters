using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using cameraatje.Contracts;
using cameraatje.Models;
using Microsoft.EntityFrameworkCore;

namespace cameraatje.Repositories
{
   public class PictureRepository : IPictureRepository
    {
        private IPictureDbContext dbContext;

        public PictureRepository(IPictureDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Picture>> GetItemsAsync()
        {
            return await dbContext.Pictures.ToListAsync();
        }
        public async Task<Picture> GetItemAsync(int id)
        {
            return await dbContext.Pictures.SingleAsync(picture => picture.foto_id == id);
        }

        public async Task<int> SaveItemAsync(Picture picture)
        {
            if (picture.kleuter_id == 0)
            {
                await dbContext.Pictures.AddAsync(picture);
            }

            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteItemAsync(Picture picture)
        {
            dbContext.Pictures.Remove(picture);

            return await dbContext.SaveChangesAsync();
        }
    }
}
