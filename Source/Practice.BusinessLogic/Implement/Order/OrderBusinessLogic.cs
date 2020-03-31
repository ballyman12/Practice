using Practice.BusinessLogic.Command.Interface;
using Practice.BusinessLogic.Interface;
using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practice.BusinessLogic.Implement.Order
{
    public class OrderBusinessLogic : IOrderBusinessLogic
    {
        public Task<ICommandBase> CreateOrder(OrderDTO item)
        {
            throw new NotImplementedException();
        }

        public ICommandBase DeleteOrder(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Domain.Model.Order>> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Model.Order> GetOrderById(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task<ICommandBase> UpdateOrder(ItemDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
