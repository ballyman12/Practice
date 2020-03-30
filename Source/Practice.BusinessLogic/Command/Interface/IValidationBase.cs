using Practice.BusinessLogic.Validation.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.BusinessLogic.Command.Interface
{
    public interface IValidationBase<T>
    {
        ValidationResult Validate(T command);
    }
}
