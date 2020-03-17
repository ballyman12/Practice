using Microsoft.EntityFrameworkCore;
using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.DataAccess.Implementation.Mapping
{
    public static class OrderStateMap
    {
        public static ModelBuilder MapOrderState(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<OrderState>();
            entity.ToTable("OrderState");
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.Type);
            //entity.Property(x => x.Action);
            entity.Property(x => x.IsDeleted);
            entity.Property(x => x.IsEnabled);

            entity.Property(x => x.OrderId).IsRequired();

            return modelBuilder;
        }
    }
}
