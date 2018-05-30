using cameraatje.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace cameraatje.Contracts
{
   public interface IPictureRepository
    {

        Task<List<Picture>> GetItemsAsync();

        Task<Picture> GetItemAsync(int id);

        Task<int> SaveItemAsync(Picture picture);

        Task<int> DeleteItemAsync(Picture picture);
    }
}
