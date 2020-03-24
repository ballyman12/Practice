using Microsoft.EntityFrameworkCore;
using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.DataAccess.Implementation.Mapping
{
    public static class OrderItemMap
    {
        public static ModelBuilder MapOrderItem(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<OrderItem>();
            entity.ToTable("Orderitems");
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.Name);
            entity.Property(x => x.Description);
            entity.Property(x => x.Note);
            entity.Property(x => x.IsDeleted);
            entity.Property(x => x.IsEnabled);
            entity.Property(x => x.CreateDate);
            entity.Property(x => x.UpdateDate);

            entity.Property(x => x.OrderId).IsRequired();
            entity.Property(x => x.ItemId).IsRequired();

            return modelBuilder;
        } 
    }
}
