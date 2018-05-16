using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using cameraatje.Models;
namespace cameraatje.Contracts
{
    public interface IToddlerRepository
    {
        Task<List<Toddler>> GetItemsAsync();

        Task<Toddler> GetItemAsync(int id);

        Task<int> SaveItemAsync(Toddler toddler);

        Task<int> DeleteItemAsync(Toddler toddler);

    }
}
