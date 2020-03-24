using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.DataAccess.Implementation.Seeding
{
    public class MockOrderItem
    {
        public static void OrderItemMock(PracticeContext context)
        {
            if (context.OrderItems.Any()) return;

            context.OrderItems.AddRange(context.Order.ToArray().Select(c => CreateOrderItem(c.Id, context)));
        }

        public static OrderItem CreateOrderItem(int orderId, PracticeContext practiceContext)
        {
            Random random = new Random();
            var cost = random.Next(50, 200);

            return new OrderItem()
            {
                OrderId = orderId,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now

            };
        }
    }
}
