using cameraatje.Contracts;
using cameraatje.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cameraatje.Repositories
{
    public class TagRepository : ITagRepository
    {
        private ITagDbContext dbContext;

        public TagRepository(ITagDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Tag>> GetItemsAsync()
        {
            return await dbContext.Tags.ToListAsync();
        }

        public async Task<Tag> GetItemAsync(int id)
        {
            return await dbContext.Tags.SingleAsync(tag => tag.foto_id == id);
        }

        public async Task<int> SaveItemAsync(Tag tag)
        {
            if (tag.foto_id == 0)
            {
                await dbContext.Tags.AddAsync(tag);
            }

            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteItemAsync(Tag tag)
        {
            dbContext.Tags.Remove(tag);

            return await dbContext.SaveChangesAsync();
        }
    }
}
