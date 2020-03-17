using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.DataAccess.Implementation.Seeding
{
    public class MockItems
    {
        public static void ItemsMock(PracticeContext context)
        {
            if (context.Items.Any()) return;

            context.Items.AddRange(Enumerable.Range(1, 5).Select(c => CreateItems(c, context)));
        }

        public static Item CreateItems(int i , PracticeContext practiceContext)
        {
            Random random = new Random();
            var cost = random.Next(50, 200);

            return new Item()
            {
                Name = "Item_" + i,
                Cost = cost,
                Unit = 10,
                SKU = SKU.Beverage,
                Barcode = i + "Items" + i,
                ItemSupplier = practiceContext.Suppliers.Take(2).Select(c => new ItemSupplier
                {
                    Supplier = c
                }).ToList()
            };
        }
    }
}
