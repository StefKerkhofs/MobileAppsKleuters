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
        public async Task<User> GetItemAsync(string mail)
        {
            return await dbContext.Users.SingleAsync(user => user.email == mail);
        }
        public async Task<string> SaveItemAsync(User user)
        {
            if (user.email == null)
            {
                await dbContext.Users.AddAsync(user);
            }

            return await dbContext.SaveChangesAsync();
        }

        public async Task<string> DeleteItemAsync(User user)
        {
            dbContext.Users.Remove(user);

            return await dbContext.SaveChangesAsync();
        }
    }
}
