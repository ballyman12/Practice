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
        public async Task<Order> GetOrderById(int orderId)
        {
            return await practiceContext.Order.Include(c => c.OrderItems).FirstOrDefaultAsync(x => x.Id == orderId);
        }
        public async Task<Order> CreateOrder(Order order)
        {
            practiceContext.Add(order);
            await practiceContext.SaveChangesAsync();

            return await GetOrderById(order.Id);
        }

        public void DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            practiceContext.Update(order);
            await practiceContext.SaveChangesAsync();

            return await GetOrderById(order.Id);
        }
    }
}
