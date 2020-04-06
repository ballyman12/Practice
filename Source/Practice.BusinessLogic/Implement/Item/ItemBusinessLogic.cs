
using Practice.BusinessLogic.Interface;
using Practice.DataAccess.Implementation;
using Practice.DataAccess.Interface;
using Practice.Domain.Model;
using Practice.Domain.Result;
using Practice.Domain.Result.Interface;
using Practice.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.BusinessLogic.Implement
{
    public class ItemBusinessLogic : IItemBusinessLogic
    {
        private readonly IItemRepository itemRepository;
        private readonly PracticeContext practiceContext;
        public ItemBusinessLogic(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public async Task<IList<Item>> GetAllItems()
        {
            return await itemRepository.GetAllItems();
        }
        public async Task<Item> GetItemById(int itemId)
        {
            return await itemRepository.GetItemById(itemId);
        }

        public async Task<ICommandBase> CreateItem(ItemDTO item)
        {
            return await itemRepository.CreateItem(item);

        }

        public async Task<ICommandBase> UpdateItem(ItemDTO item)
        {

            return await itemRepository.UpdateItem(item);

        }

        public async Task<ICommandBase> DeleteItem(int itemId)
        {
            return await itemRepository.DeleteItem(itemId);

        }
    }
}
