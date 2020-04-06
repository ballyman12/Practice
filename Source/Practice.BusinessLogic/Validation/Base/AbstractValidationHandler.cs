using FluentValidation;
using Practice.Domain.Result;
using Practice.Domain.Result.Interface;
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

        public ValidationResult Validate(IValidator<T> validator, T command, string ruleSet)
        {
            return new ValidationResult(DefaultValidatorExtensions.Validate(validator, command, ruleSet));
        }
    }
}
