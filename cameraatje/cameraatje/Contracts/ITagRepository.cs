using cameraatje.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cameraatje.Contracts
{
   public interface ITagRepository
    {
        Task<List<Tag>> GetItemsAsync();

        Task<Tag> GetItemAsync(int id);

        Task<int> SaveItemAsync(Tag tag);

        Task<int> DeleteItemAsync(Tag tag);
    }
}
