using Practice.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Domain.Model
{
    public class User : EntityDescription
    {    
        public string Username { get; set; }
        public string Password { get; set; }
        public string SecurityToken { get; set; }
    }
}
