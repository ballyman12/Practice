using Practice.BusinessLogic.Command.Interface;
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

            var hasItemName = practiceContext.Items.Any(c => c.Name.ToLower().Equals(item.ItemName.ToLower()));
            if(hasItemName)
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

        public async Task<ICommandBase> UpdateItem(ItemDTO item)
        {
            var _item = practiceContext.Items.FirstOrDefault(c => c.Id == item.ItemId);

            if(_item == null)
                return new CommandResult(false, "Item not found");

            var hasItemName = practiceContext.Items.Any(c => c.Name.ToLower().Equals(item.ItemName.ToLower()) && c.Id != item.ItemId);
            if (hasItemName)
                return new CommandResult(false, $"Item' name '{item.ItemName}' has already in the database");

            var hasBarcode = practiceContext.Items.Any(c => c.Barcode.ToLower().Equals(item.Barcode.ToLower()) && c.Id != item.ItemId);
            if (hasBarcode)
                return new CommandResult(false, $"Item's Barcode '{item.Barcode}' has already in ther database");

            _item.Name = item.ItemName;
            _item.SKU = item.SKU;
            _item.Cost = item.Cost;
            _item.Unit = item.Unit;
            _item.Barcode = item.Barcode;


            await itemRepository.UpdateItem(_item);

            return new CommandResult();
        }

        public ICommandBase DeleteItem(int itemId)
        {
            var _item = practiceContext.Items.FirstOrDefault(c => c.Id == itemId);

            if(_item == null)
                return new CommandResult(false, "Item not found");

            itemRepository.DeleteItem(_item);

            return new CommandResult();
        }
    }
}
