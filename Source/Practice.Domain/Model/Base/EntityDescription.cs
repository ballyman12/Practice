using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Domain.Model.Base
{
    abstract public class EntityDescription : EntityBase, EntityStatus
    {
        public int Id { get; set; }
        public bool IsEnabled { get; set; } = true ;
        public bool IsDeleted { get; set; } = false ;
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
    }
}
