using Practice.DataAccess.Interface;
using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.DataAccess.Implementation.Seeding
{
    public class MockUsers
    {
        public static void CreateUser(PracticeContext context)
        {
            var user = new User()
            {
                Username = "Hello",
                Password = "",
                SecurityToken = "",
                Name = "Ball"
                
            };

            context.Add(user);
            context.SaveChanges();
        }
    }
}
