
using Practice.BusinessLogic.Interface;

using Practice.Domain.Model;
using Practice.Domain.Result;
using Practice.Domain.Result.Interface;
using Practice.Repository.Interface;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.BusinessLogic.Implement
{
    public class ItemBusinessLogic : IItemBusinessLogic
    {
        private readonly IItemRepository itemRepository;
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
            var _item = new Item
            {
                Name = item.ItemName,
                SKU = item.SKU,
                Cost = item.Cost,
                Unit = item.Unit,
                Barcode = item.Barcode
            };

            var result = await itemRepository.CreateItem(_item);
            item.ItemId = _item.Id;

            return result;

        }

        public async Task<ICommandBase> UpdateItem(ItemDTO item)
        {
            var _item = new Item
            {
                Id = item.ItemId,
                Name = item.ItemName,
                SKU = item.SKU,
                Cost = item.Cost,
                Unit = item.Unit,
                Barcode = item.Barcode
            };

            return await itemRepository.UpdateItem(_item);

        }

        public async Task<ICommandBase> DeleteItem(int itemId)
        {
            return await itemRepository.DeleteItem(itemId);

        }
    }
}
