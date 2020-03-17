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
        public int ItemId { get; set; }
    }
}
