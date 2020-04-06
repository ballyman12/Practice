using Practice.Domain.Model;
using Practice.Domain.Result.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Repository.Interface
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Task<IList<Order>> GetAllOrder();
        Task<Order> GetOrderById(int orderId);
        Task<ICommandBase> CreateOrder(Order order);
        Task<ICommandBase> UpdateOrder(Order order);
        Task<ICommandBase> DeleteOrder(int orderId);
    }
}
