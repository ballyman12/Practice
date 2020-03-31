using Practice.BusinessLogic.Command.Interface;
using Practice.BusinessLogic.Command.Result;
using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practice.BusinessLogic.Interface
{
    public interface IItemBusinessLogic : IBusinessLogicBase<Item>
    {
        Task<IList<Item>> GetAllItems();
        Task<Item> GetItemById(int itemId);
        Task<ICommandBase> CreateItem(ItemDTO item);
        Task<ICommandBase> UpdateItem(ItemDTO item);
        ICommandBase DeleteItem(int itemId);
    }
}
