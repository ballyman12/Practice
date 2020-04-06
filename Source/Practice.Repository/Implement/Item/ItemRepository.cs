using Practice.DataAccess.Implementation;
using Practice.Domain.Model;
using Practice.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Practice.Domain.Result.Interface;
using Practice.Domain.Result;

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
        public async Task<ICommandBase> CreateItem(Item item)
        {
            var hasItemName = practiceContext.Items.Any(c => c.Name.ToLower().Equals(item.Name.ToLower()));
            if (hasItemName)
                return new CommandResult(false, $"Item {item.Name} has already exists");

            var hasBarcode = practiceContext.Items.Any(c => c.Barcode.ToLower().Equals(item.Barcode.ToLower()));
            if (hasBarcode)
                return new CommandResult(false, $"Item's Barcode {item.Barcode} has already exists");

            practiceContext.Items.Add(item);
            await practiceContext.SaveChangesAsync();       

            return new CommandResult();
        }

        public async Task<ICommandBase> UpdateItem(Item item)
        {
            var _item = practiceContext.Items.FirstOrDefault(c => c.Id == item.Id);

            if (_item == null)
                return new CommandResult(false, "Item not found");

            var hasItemName = practiceContext.Items.Any(c => c.Name.ToLower().Equals(item.Name.ToLower()) && c.Id != item.Id);
            if (hasItemName)
                return new CommandResult(false, $"Item' name '{item.Name}' has already in the database");

            var hasBarcode = practiceContext.Items.Any(c => c.Barcode.ToLower().Equals(item.Barcode.ToLower()) && c.Id != item.Id);
            if (hasBarcode)
                return new CommandResult(false, $"Item's Barcode '{item.Barcode}' has already in ther database");

            _item.Name = item.Name;
            _item.SKU = item.SKU;
            _item.Cost = item.Cost;
            _item.Unit = item.Unit;
            _item.Barcode = item.Barcode;

            practiceContext.Items.Update(_item);
            await practiceContext.SaveChangesAsync();


            return new CommandResult();
        }

        public async Task<ICommandBase> DeleteItem(int itemId)
        {
            var _item = practiceContext.Items.FirstOrDefault(c => c.Id == itemId);

            if (_item == null)
                return new CommandResult(false, "Item not found");

            practiceContext.Items.Remove(_item);
            await practiceContext.SaveChangesAsync();

            return new CommandResult();
        }
    }
}
