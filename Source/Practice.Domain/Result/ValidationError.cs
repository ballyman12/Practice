using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Domain.Result
{
    public class ValidationError
    {
        public object AttemptedValue { get; set; }
        public string ErrorMessage { get; set; }
        public string PropertyName { get; set; }
    }
}
