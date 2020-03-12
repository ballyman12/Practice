using Practice.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Domain.Model
{
    public class Order : EntityDescription
    {
        public Supplier Supplier { get; set; }
        public Item[] Items { get; set; }
    }
}
