using System;
using System.Collections.Generic;
using System.Text;
using cameraatje.Models;
using System.Threading.Tasks;
namespace cameraatje.Contracts
{
    public interface IRepository
    {
        Task<List<Picture>> GetPicturesAsync();
        Task<List<Toddler>> GetToddlersAsync();
        Task<List<Tag>> GetTagsAsync();
        Task<List<User>> GetUsersAsync();
        Task<List<Corner>> GetCornersAsync();
    }
}
