using cameraatje.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cameraatje.Contracts
{
   public interface ICornerRepository
    {
        Task<List<Corner>> GetItemsAsync();

        Task<Corner> GetItemAsync(int id);

        Task<int> SaveItemAsync(Corner corner);

        Task<int> DeleteItemAsync(Corner corner);

    }
}
