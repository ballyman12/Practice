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
    }
}
