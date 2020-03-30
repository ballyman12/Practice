using Practice.BusinessLogic.Command.Result;
using Practice.BusinessLogic.Interface;
using Practice.DataAccess.Implementation;
using Practice.DataAccess.Interface;
using Practice.Domain.Model;
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
        public ItemBusinessLogic(IItemRepository itemRepository, PracticeContext practiceContext)
        {
            this.itemRepository = itemRepository;
            this.practiceContext = practiceContext;
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

        public async Task<CommandResult> CreateItem(ItemDTO item)
        {
            if (item == null) return null;

            var hasItem = practiceContext.Items.Any(c => c.Name.ToLower().Equals(item.ItemName.ToLower()));
            if(hasItem)
                return new CommandResult(false, $"Item {item.ItemName} has already exists");

            var hasBarcode = practiceContext.Items.Any(c => c.Barcode.ToLower().Equals(item.Barcode.ToLower()));
            if (hasBarcode)
                return new CommandResult(false, $"Item's Barcode {item.Barcode} has already exists");

            var _item = new Item
            {
                Name = item.ItemName,
                SKU = item.SKU,
                Cost = item.Cost,
                Unit = item.Unit,
                Barcode = item.Barcode
            };

            await itemRepository.CreateItem(_item);

            item.ItemId = _item.Id;
            return new CommandResult();
        }
    }
}
