using Microsoft.AspNetCore.Identity;
using Practice.Domain.Result.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.Domain.Result
{
    public class CommandResult : ICommandBase
    {
        public bool Success { get; protected set; }
        public IEnumerable<string> Errors { get; set; }
        public CommandResult(bool success = true)
        {
            this.Success = success;
            this.Errors = new List<string>();
        }

        public CommandResult(IdentityResult result)
        {
            if (result.Succeeded)
                this.Success = true;
            else
            {
                this.Success = false;
                this.Errors = result.Errors.Select(x => x.Description).ToList();
            }
        }

        public CommandResult(bool success, IEnumerable<string> errors)
        {
            this.Success = success;
            this.Errors = errors;
        }

        public CommandResult(bool success, string error)
        {
            this.Success = success;
            this.Errors = new List<string> { error };
        }

        
    }
}
