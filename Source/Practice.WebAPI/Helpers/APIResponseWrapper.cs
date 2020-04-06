
using Practice.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.WebAPI.Helpers
{
    public class APIResponseWrapper<T>
    {
        public T Data { get; set; }
        public IEnumerable<object> Errors { get; set; }
        public bool IsComplete { get; set; }

        public static APIResponseWrapper<T> StatusComplete(T data)
        {
            return new APIResponseWrapper<T>()
            {
                Data = data,
                IsComplete = true
            };
        }

        public static APIResponseWrapper<T> StatusFailed(ValidationResult messageFail)
        {
            return new APIResponseWrapper<T>()
            {
                IsComplete = false,
                Errors = messageFail.Errors
            };
        }

    }
}
