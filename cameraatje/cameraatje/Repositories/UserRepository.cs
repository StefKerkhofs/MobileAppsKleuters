using cameraatje.Contracts;
using cameraatje.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cameraatje.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IUserDbContext dbContext;

        public UserRepository(IUserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<User>> GetItemsAsync()
        {
            return await dbContext.Users.ToListAsync();
        }
        public async Task<User> GetItemAsync(int id)
        {
            return await dbContext.Users.SingleAsync(user => user.user_id == id);
        }
        public async Task<int> SaveItemAsync(User user)
        {
            if (user.user_id == 0)
            {
                await dbContext.Users.AddAsync(user);
            }

            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteItemAsync(User user)
        {
            dbContext.Users.Remove(user);

            return await dbContext.SaveChangesAsync();
        }
    }
}
