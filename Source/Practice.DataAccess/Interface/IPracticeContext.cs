using Microsoft.EntityFrameworkCore;
using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.DataAccess.Interface
{
    public interface IPracticeContext : IDisposable
    {
        DbSet<User> Users { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<Supplier> Suppliers { get; set; }
        DbSet<Order> Order { get; set; }
        DbSet<UserState> UserStates { get; set; }
        DbSet<ItemState> ItemStates { get; set; }
        DbSet<SupplierState> SupplierStates { get; set; }
        DbSet<OrderState> OrderrStates { get; set; }
    }
}
