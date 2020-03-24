using Microsoft.EntityFrameworkCore;
using Practice.DataAccess.Implementation.Mapping;
using Practice.DataAccess.Interface;
using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.DataAccess.Implementation
{
    public class PracticeContext : DbContext , IPracticeContext
    {
        public PracticeContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get ; set ; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<UserState> UserStates { get; set; }
        public DbSet<ItemState> ItemStates { get; set; }
        public DbSet<SupplierState> SupplierStates { get; set; }
        public DbSet<OrderState> OrderStates { get; set; }
        public DbSet<ActionState> ActionStates { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapItem();
            modelBuilder.MapItemState();
            modelBuilder.MapUser();
            modelBuilder.MapUserState();
            modelBuilder.MapOrder();
            modelBuilder.MapOrderState();
            modelBuilder.MapSupplier();
            modelBuilder.MapSupplierState();
            modelBuilder.MapItemSupplier();
            modelBuilder.MapActionState();
            modelBuilder.MapOrderItem();

            base.OnModelCreating(modelBuilder);
        }

    }
}
