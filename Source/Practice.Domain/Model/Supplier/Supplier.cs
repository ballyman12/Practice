using Practice.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Domain.Model
{
    public class Supplier : EntityDescription
    {
        
        public string Address { get; set; }
        public virtual ICollection<ItemSupplier> ItemSupplier { get; set; }
        public string PhoneNo { get; set; }
    }
}
