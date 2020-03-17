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

            context.Order.AddRange(Enumerable.Range(1, 5).Select(c => CreateOrder(c, context)));
        }

        public static Order CreateOrder(int i , PracticeContext context)
        {
            var suppliers = context.Suppliers.ToArray();
            var item = context.Items.ToArray();

            return new Order()
            {
                Name = "Receipt_" + i,
                Supplier = suppliers.FirstOrDefault(),
                Items = item
            };
        }
    }
}
