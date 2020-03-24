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

        public ItemDTO ToDTO()
        {
            return new ItemDTO
            {
                ItemId = Id,
                ItemName = Name,
                SKU = SKU,
                Cost = Cost,
                Unit = Unit,
                Barcode = Barcode

            };
        }
    }

    public class ItemDTO 
    { 
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public SKU SKU { get; set; }
        public double Cost { get; set; }
        public int Unit { get; set; }
        public string Barcode { get; set; }
    }

}
