using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Domain.Model.Base
{
    public interface IEntityBase
    {
        int Id { get; set; }
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
    }
}
