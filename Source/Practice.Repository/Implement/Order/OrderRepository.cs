using Microsoft.EntityFrameworkCore;
using Practice.DataAccess.Implementation;
using Practice.Domain.Model;
using Practice.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Repository.Implement
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PracticeContext practiceContext;
        public OrderRepository(PracticeContext practiceContext)
        {
            this.practiceContext = practiceContext;
        }
        public async Task<IList<Order>> GetAllOrder()
        {
            return await practiceContext.Order.Include(c => c.OrderItems).ToListAsync();
        }
        public Task<Order> GetOrderById(int orderId)
        {
            throw new NotImplementedException();
        }
        public Task<Order> CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
