﻿using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.DataAccess.Implementation.Seeding
{
    public class MockUsersState
    {
        public static void UsersStateMock(PracticeContext context)
        {
            if (context.UserStates.Any()) return;
            var user = context.Users.FirstOrDefault();
           
            var userState = context.Order.ToArray().Select(c => new UserState
            {
                UserId = c.Id,
                Type = StateType.Get
            });

            context.UserStates.AddRange(userState);
            context.SaveChanges();
        }
    }
}