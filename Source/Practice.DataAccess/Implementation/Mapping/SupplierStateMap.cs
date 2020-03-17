using Microsoft.EntityFrameworkCore;
using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.DataAccess.Implementation.Mapping
{
    public static class SupplierStateMap
    {
        public static ModelBuilder MapSupplierState(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<SupplierState>();
            entity.ToTable("SupplierState");
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.Type);
            //entity.Property(x => x.Action);
            entity.Property(x => x.IsDeleted);
            entity.Property(x => x.IsEnabled);

            entity.Property(x => x.SupplierId).IsRequired();

            return modelBuilder;
        }
    }
}
