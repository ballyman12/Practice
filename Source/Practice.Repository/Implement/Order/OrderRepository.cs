using Microsoft.EntityFrameworkCore;
using Practice.DataAccess.Implementation;
using Practice.Domain.Model;
using Practice.Domain.Result;
using Practice.Domain.Result.Interface;
using Practice.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ICommandBase> CreateOrder(Order order)
        {
            var hasOrderName = practiceContext.Order.Any(c => c.Name.ToLower().Equals(order.Name.ToLower()));
            if (hasOrderName)
                return new CommandResult(false, $"Order's name {order.Name} has already exists");

            practiceContext.Add(order);
            await practiceContext.SaveChangesAsync();

            return new CommandResult();
        }

        public async Task<ICommandBase> DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<ICommandBase> UpdateOrder(Order order)
        {
            var _order = practiceContext.Order.FirstOrDefault(x => x.Id == order.Id);
            if (_order == null) return new CommandResult(false, $"Order not found.");


            var hasOrderName = practiceContext.Order.Any(c => c.Name.ToLower().Equals(order.Name.ToLower()) && c.Id != order.Id);
            if (hasOrderName)
                return new CommandResult(false, $"Order's name {order.Name} has already exists");

            _order.Name = order.Name;
            _order.SupplierId = order.SupplierId;

            practiceContext.Update(order);
            await practiceContext.SaveChangesAsync();

            return new CommandResult();
        }
    }
}
