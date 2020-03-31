using Practice.BusinessLogic.Command.Interface;
using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practice.BusinessLogic.Interface
{
    public interface IOrderBusinessLogic
    {
        Task<IList<Order>> GetAllOrders();
        Task<Order> GetOrderById(int itemId);
        Task<ICommandBase> CreateOrder(OrderDTO item);
        Task<ICommandBase> UpdateOrder(ItemDTO item);
        ICommandBase DeleteOrder(int itemId);
    }
}
