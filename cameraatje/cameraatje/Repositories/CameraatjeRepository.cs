using System;
using System.Collections.Generic;
using System.Text;
using cameraatje.Models;
using cameraatje.Contracts;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace cameraatje.Repositories
{
    public class CameraatjeRepository : IRepository
    {
        private IDbContext dbContext;
        private List<Picture> pictures = new List<Picture>();
        private List<Toddler> toddler = new List<Toddler>();
        
        public CameraatjeRepository(IDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public async Task<List<Corner>> GetCornersAsync()
        {
            return await dbContext.Corner.ToListAsync();
        }

        public async Task<List<Picture>> GetPicturesAsync()
        {
            //test email
            var userEmail = "sasha@test.com";
            //pak de kleuter id van de user met het overeenkomende email
            var id = from user in dbContext.User
                     where user.email == userEmail
                     select user.kleuter_id;

            //genereer een photolist
            var pictureList = from picture in dbContext.Picture
                            where picture.kleuter_id == Convert.ToInt32(id)
                            select picture;
            pictures.AddRange(pictureList);

            await Task.Run<List<Picture>>(() =>
            {
                return pictures;
            }
            );
            return null;
            
        }

        public async Task<List<Tag>> GetTagsAsync()
        {
            return await dbContext.Tag.ToListAsync();
        }

        public async Task<List<Toddler>> GetToddlersAsync()
        {
            return await dbContext.Toddler.ToListAsync();

        }   public async Task<Toddler> GetToddlerAsync( int id)
        {
            await Task.Run<Toddler>(() =>
            {
                var tod = from toddler in dbContext.Toddler
                             where toddler.kleuter_id == id
                             select toddler;
                return (Toddler)tod;
            }
                                   );
            return null;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await dbContext.User.ToListAsync();
        }
        public async Task<User> GetUserAsync(string email)
        {
           
            await Task.Run<User>(() =>
            { var person = from user in dbContext.User
                     where user.email == email
                     select user;
                return (User)person;
            }
                       );
            return null;
        }
    }
}
