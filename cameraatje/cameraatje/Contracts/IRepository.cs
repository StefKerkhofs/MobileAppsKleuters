﻿using System;
using System.Collections.Generic;
using System.Text;
using cameraatje.Models;
using System.Threading.Tasks;
namespace cameraatje.Contracts
{
    //Author: Sasha van de Voorde
    public interface IRepository
    {
        Task<List<Picture>> GetPicturesAsync();
        Task<List<Toddler>> GetToddlersAsync();
        Task<Toddler> GetToddlerAsync(int id);
        Task<List<Tag>> GetTagsAsync();
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserAsync(string email);
        Task<List<Corner>> GetCornersAsync();
    }
}
