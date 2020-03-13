using Practice.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Domain.Model
{
    public class Item : EntityDescription
    {
        public SKU SKU { get; set; }
        public double Cost { get; set; }
        public int Unit { get; set; }
        public string Barcode { get; set; }
        public virtual ICollection<ItemSupplier> ItemSupplier { get; set; }
    }
}
