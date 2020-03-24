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
            
            context.Order.AddRange(Enumerable.Range(1,5).Select(c => CreateOrder(c , context)));
            context.SaveChanges();
        }

        public static Order CreateOrder(int Id, PracticeContext context)
        {
            var suppliers = context.Suppliers.ToArray();

            return new Order()
            {
                Name = "Receipt_" + Id,
                SupplierId = suppliers.FirstOrDefault().Id,
                OrderItems = context.Items.Take(3).Select(c => new OrderItem
                {
                    Item = c
                }).ToList(),
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now

            };
        }
    }
}
