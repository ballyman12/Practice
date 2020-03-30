using FluentValidation;
using Practice.BusinessLogic.Command.Interface;
using Practice.BusinessLogic.Validation.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.BusinessLogic.Command.Base
{
    public abstract class AbstractValidationHandler<T> : AbstractValidator<T>, IValidationBase<T>
    {
        public new ValidationResult Validate(T command)
        {
            return new ValidationResult(base.Validate(command));
        }
    }
}
