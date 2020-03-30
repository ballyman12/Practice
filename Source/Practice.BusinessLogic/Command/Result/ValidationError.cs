using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.BusinessLogic.Validation.Result
{
    public class ValidationError
    {
        public object AttemptedValue { get; set; }
        public string ErrorMessage { get; set; }
        public string PropertyName { get; set; }
    }
}
