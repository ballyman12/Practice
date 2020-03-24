using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.DataAccess.Implementation.Seeding
{
    public class MockActionState
    {
        public static void ActionStateMock(PracticeContext context)
        {
            if (context.ActionStates.Any()) return;

            var user = context.Users.FirstOrDefault();

            var action = new ActionState()
            {
                By = user.Id,
                On = DateTime.Now.Ticks
            };

            context.ActionStates.Add(action);
            context.SaveChanges();
        }
    }
}
