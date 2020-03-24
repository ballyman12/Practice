using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.DataAccess.Implementation.Seeding
{
    public class MockSuppliers
    {
        public static void SupplierMock(PracticeContext context)
        {
            if (context.Suppliers.Any()) return;

            context.Suppliers.AddRange(Enumerable.Range(1, 5).Select(c => new Supplier
            {
                Name = "Supplier_" + c,
                Address = "Thailand",
                PhoneNo = "084-874"+ c,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now
            }));

            context.SaveChanges();
        }
    }
}
