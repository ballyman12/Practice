using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Domain.Model.Base
{
    public interface IEntityStatus
    {
        bool IsEnabled { get; set; }
        bool IsDeleted { get; set; }

    }
}
