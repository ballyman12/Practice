using Practice.Domain.Model;
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
        Task<Order> CreateOrder(Order order);
        Task<Order> UpdateOrder(Order order);
        void DeleteOrder(int orderId);
    }
}
