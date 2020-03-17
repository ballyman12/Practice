using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.DataAccess.Implementation.Seeding
{
    public class MockOrdersState
    {
        public static void OrdersStateMock(PracticeContext context)
        {
            if (context.OrderStates.Any()) return;
            
            var order = context.Order.ToArray().Select(c => new OrderState
            {
                OrderId = c.Id,
                Type = StateType.Get,
                ActionStateId = context.ActionStates.Select(x => x.Id).FirstOrDefault()
            });

            context.OrderStates.AddRange(order);
            context.SaveChanges();
        }
    }
}
