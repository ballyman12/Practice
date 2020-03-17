using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.DataAccess.Implementation.Seeding
{
    public class MockItemsState
    {
        public static void ItemsStateMock(PracticeContext context)
        {
            if (context.ItemStates.Any()) return;
         
            var item = context.Items.ToArray().Select(c => new ItemState
            {
                ItemId = c.Id,
                Type = StateType.Get,
            });

            context.ItemStates.AddRange(item);
            context.SaveChanges();
        }
    }
}
