using Practice.BusinessLogic.Command.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.BusinessLogic.Validation.Result
{
    public class ValidationResult : ICommandBase
    {

        public ValidationResult()
        {

        }

        public ValidationResult(IList<ValidationError> errors) : this()
        {
            Errors = errors;
        }

        public ValidationResult(FluentValidation.Results.ValidationResult validationResult)
        {
            Errors = validationResult.Errors.Select(x => new ValidationError() { AttemptedValue = x.AttemptedValue, ErrorMessage = x.ErrorMessage, PropertyName = x.PropertyName }).ToList();
        }


        public IList<ValidationError> Errors { get; set; } = new List<ValidationError>();
        public bool IsValid
        {
            get
            {
                if (Errors.Count() > 0)
                    return false;
                else
                    return true;
            }
        }

        public ValidationResult(object attemptedValue, string errorMessage, string propertyName)
        {
            Errors.Add(new ValidationError()
            {
                AttemptedValue = attemptedValue,
                ErrorMessage = errorMessage,
                PropertyName = propertyName
            });

        }
    }
}
