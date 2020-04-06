using Practice.Domain.Model;
using Practice.Domain.Result.Interface;
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
        Task<ICommandBase> CreateItem(Item item);
        Task<ICommandBase> UpdateItem(Item item);
        Task<ICommandBase> DeleteItem(int itemId);

    }
}
