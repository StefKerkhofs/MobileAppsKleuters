using cameraatje.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cameraatje.Contracts
{
   public interface IUserRepository
    {
        Task<List<User>> GetItemsAsync();

        Task<User> GetItemAsync(int id);

        Task<int> SaveItemAsync(User user);

        Task<int> DeleteItemAsync(User user);
    }
}
