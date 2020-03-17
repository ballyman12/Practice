using Practice.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Domain.Model
{
    public class ItemState : EntityState
    {
        public int ItemId { get; set; }
        public int ActionStateId { get; set; }
    }
}
