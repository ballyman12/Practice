using Practice.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Domain.Model
{
    public class OrderState : EntityState
    {
        public int OrderId { get; set; }
        public ActionState Action { get; set; }
        public int ActionStateId { get; set; }
    }
}
