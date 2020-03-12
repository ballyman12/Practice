using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Domain.Model.Base
{
    abstract public class EntityState : EntityBase, EntityStatus
    {
        public int Id { get ; set ; }
        public bool IsEnabled { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public StateType Type { get; set; }
        public ActionState Action { get; set; }
    }
}
