using Practice.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Domain.Model
{
    public class ActionState : EntityBase
    {
        public int By { get; set; }
        public long On { get; set; }
        public int Id { get; set; }
    }
}
