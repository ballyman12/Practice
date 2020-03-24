using Practice.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Domain.Model
{
    public class Order : EntityDescription
    {
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public string SupplierName { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }
}
