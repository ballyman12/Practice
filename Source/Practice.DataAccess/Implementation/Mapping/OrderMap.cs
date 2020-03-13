using Microsoft.EntityFrameworkCore;
using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.DataAccess.Implementation.Mapping
{
    public static class OrderMap
    {
        public static ModelBuilder MapOrder(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Order>();
            entity.ToTable("Orders");
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.Name);
            entity.Property(x => x.Description);
            entity.Property(x => x.Note);
            entity.Property(x => x.IsDeleted);
            entity.Property(x => x.IsEnabled);

            entity.HasOne(x => x.Supplier);

            entity.HasMany(x => x.Items);

            return modelBuilder;
        }
    }
}
