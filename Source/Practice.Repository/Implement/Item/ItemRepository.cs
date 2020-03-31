using Practice.DataAccess.Implementation;
using Practice.Domain.Model;
using Practice.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Practice.Repository.Implement
{
    public class ItemRepository : IItemRepository
    {
        private readonly PracticeContext practiceContext;
        public ItemRepository(PracticeContext practiceContext)
        {
            this.practiceContext = practiceContext;
        }
        public async Task<IList<Item>> GetAllItems()
        {
            return await practiceContext.Items.ToListAsync();
        }
        public async Task<Item> GetItemById(int itemId)
        {
            return await practiceContext.Items.FirstOrDefaultAsync(x => x.Id == itemId);
        }
        public async Task<Item> CreateItem(Item item)
        {
            if (item == null) return new Item();

            practiceContext.Items.Add(item);
            practiceContext.SaveChanges();

            return await GetItemById(item.Id);
        }

        public async Task<Item> UpdateItem(Item item)
        {
            if (item == null) return new Item();

            practiceContext.Items.Update(item);
            practiceContext.SaveChanges();

            return await GetItemById(item.Id);
        }
    }
}
