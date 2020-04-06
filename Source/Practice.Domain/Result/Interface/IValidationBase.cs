using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Domain.Result.Interface
{
    public interface IValidationBase<T>
    {
        ValidationResult Validate(T command);
    }
}
