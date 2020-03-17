using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Practice.DataAccess.Implementation.Seeding;
using Practice.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.DataAccess.Implementation
{
    public static class DBContextExtensions
    {
        public static bool AllMigrationApplied(this PracticeContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void EnsureSeeded(this PracticeContext context)
        {
            if (!context.Users.Any())
            {
                MockUsers.CreateUser(context);
            }
            MockSuppliers.SupplierMock(context);
            MockItems.ItemsMock(context);
            MockOrders.OrderMock(context);

            MockItemsState.ItemsStateMock(context);
            MockOrdersState.OrdersStateMock(context);
            MockSuppliersState.SupplierStateMock(context);
            MockUsersState.UsersStateMock(context);
        }
    }
}
