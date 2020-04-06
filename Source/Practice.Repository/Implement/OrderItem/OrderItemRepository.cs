using Microsoft.EntityFrameworkCore;
using Practice.DataAccess.Implementation;
using Practice.Domain.Model;
using Practice.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Repository.Implement
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly PracticeContext practiceContext;
        public OrderItemRepository(PracticeContext practiceContext)
        {
            this.practiceContext = practiceContext;
        }
        public async Task UpdateOrdertem(IEnumerable<int> itemId, int orderId)
        {
            var order = practiceContext.Order
                .Include(x => x.OrderItems)
                .Single(x => x.Id == orderId);

            var orderItem = practiceContext.Items
                .Where(x => itemId.Contains(x.Id))
                .Select(x => new OrderItem()
                {
                    OrderId = order.Id,
                    Order = order,
                    ItemId = x.Id,
                    Item = x
                }).ToList();

            order.OrderItems = orderItem;

            practiceContext.Order.Update(order);
            await practiceContext.SaveChangesAsync();
        }
    }
}
