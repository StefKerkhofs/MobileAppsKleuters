using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using cameraatje.Models;
using cameraatje.Contracts;
using Microsoft.EntityFrameworkCore;

namespace cameraatje.Repositories
{
    public class ToddlerRepository : IToddlerRepository
    {
        private IToddlerDbContext dbContext;

        public ToddlerRepository(IToddlerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Toddler>> GetItemsAsync()
        {
            return await dbContext.Toddlers.ToListAsync();
        }

       
        public async Task<Toddler> GetItemAsync(int id)
        {
            return await dbContext.Toddlers.SingleAsync(toddler => toddler.kleuter_id == id);

            //var todoItem = from item in dbContext.TodoItems
            //               where item.ID == id
            //               select item;

            //return await todoItem.SingleAsync();
        }

        public async Task<int> SaveItemAsync(Toddler toddler)
        {
            if (toddler.kleuter_id == 0)
            {
                await dbContext.Toddlers.AddAsync(toddler);
            }

            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteItemAsync(Toddler toddler)
        {
            dbContext.Toddlers.Remove(toddler);

            return await dbContext.SaveChangesAsync();
        }
    }
}
