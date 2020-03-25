using Practice.BusinessLogic.Interface;
using Practice.Domain.Model;
using Practice.Repository.Interface;
using System;
using System.Collections.Generic;
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
        public void Delete(int internalId)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Item>> GetAllItems()
        {
            return await itemRepository.GetAllItems();
        }
        public async Task<Item> GetItemById(int itemId)
        {
            return await itemRepository.GetItemById(itemId);
        }

        public Task<Item> GetById(int internalId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Item>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<Item> Save(Item item)
        {
            throw new NotImplementedException();
        }

        public Task<Item> Update(Item item)
        {
            throw new NotImplementedException();
        }

        public async Task<Item> CreateItem(ItemDTO item)
        {
            if (item == null) return null;

            var _item = new Item
            {
                Name = item.ItemName,
                SKU = item.SKU,
                Cost = item.Cost,
                Unit = item.Unit,
                Barcode = item.Barcode
            };

            return await itemRepository.CreateItem(_item);
        }
    }
}
