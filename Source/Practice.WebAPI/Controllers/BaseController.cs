using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Domain.Result;
using Practice.Domain.Result.Interface;
using Practice.WebAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.WebAPI.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {

        }
        protected async Task<ActionResult<APIResponseWrapper<T>>> APIResponse<T>(Task<T> result,
            int failureStatusCode = StatusCodes.Status500InternalServerError)
        {
            return InternalAPIResponse<T>(await result, failureStatusCode);
        }
        protected ActionResult<APIResponseWrapper<T>> APIResponse<T>(ICommandBase result, int failureStatusCode = StatusCodes.Status500InternalServerError)
        {
            return InternalAPIResponse<T>(result, failureStatusCode);
        }
        protected ActionResult<APIResponseWrapper<T>> APIResponse<T>(T result,
            int failureStatusCode = StatusCodes.Status500InternalServerError)
        {
            return InternalAPIResponse<T>(result, failureStatusCode);
        }

        private ActionResult<APIResponseWrapper<T>> InternalAPIResponse<T>(object result,
            int failureStatusCode = StatusCodes.Status500InternalServerError)
        {
            var apiResponse = new APIResponseWrapper<T>();
            if (result is ValidationResult validationResult)
            {
                apiResponse.Errors = validationResult.Errors;
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            else if(result is CommandResult commandResult)
            {
                apiResponse.Errors = commandResult.Errors;
                HttpContext.Response.StatusCode = commandResult.Success ? StatusCodes.Status200OK : failureStatusCode;
                apiResponse.IsComplete = commandResult.Success ? true : false;
            }

            if (result is T data)
            {
                apiResponse.Data = data;
                apiResponse.IsComplete = HttpContext.Response.StatusCode == StatusCodes.Status200OK ? true : false ;
            }

            return apiResponse;
        }

    }
}
