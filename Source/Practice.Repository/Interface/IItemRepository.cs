using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Repository.Interface
{
    public interface IItemRepository : IRepositoryBase<Item>
    {
        Task<IList<Item>> GetAllItems();
        Task<Item> GetItemById(int itemId);
        Task<Item> CreateItem(Item item);
        Task<Item> UpdateItem(Item item);
        void DeleteItem(Item item);

    }
}
