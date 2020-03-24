using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Domain.Model.Base
{
    abstract public class EntityState : IEntityBase, IEntityStatus
    {
        public int Id { get ; set ; }
        public bool IsEnabled { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public StateType Type { get; set; }
        public  DateTime CreateDate { get; set; }
        public  DateTime UpdateDate { get; set; }
    }
}
