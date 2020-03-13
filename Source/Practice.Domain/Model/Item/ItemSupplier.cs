using Practice.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Domain.Model
{
    public class ItemSupplier : EntityDescription
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
