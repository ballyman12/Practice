using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.DataAccess.Implementation.Seeding
{
    public class MockSuppliersState
    {
        public static void SupplierStateMock(PracticeContext context)
        {
            if (context.SupplierStates.Any()) return;
            var user = context.Users.FirstOrDefault();

            var supplier = context.Suppliers.ToArray().Select(c => new SupplierState
            {
                SupplierId = c.Id,
                Type = StateType.Get,
                ActionStateId = context.ActionStates.Select(x => x.Id).FirstOrDefault(),
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now

            });

            context.SupplierStates.AddRange(supplier);
            context.SaveChanges();
        }
    }
}
