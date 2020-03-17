using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.DataAccess.Implementation.Seeding
{
    public class MockOrders
    {
        public static void OrderMock(PracticeContext context)
        {
            if (context.Order.Any()) return;
            
            context.Order.AddRange(context.Items.ToArray().Take(5).Select(c => CreateOrder(c.Id, context)));
        }

        public static Order CreateOrder(int itemId, PracticeContext context)
        {
            var suppliers = context.Suppliers.ToArray();

            return new Order()
            {
                Name = "Receipt_" + itemId,
                SupplierId = suppliers.FirstOrDefault().Id,
                ItemId = itemId
            };
        }
    }
}
