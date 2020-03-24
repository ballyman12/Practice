using Microsoft.EntityFrameworkCore;
using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.DataAccess.Implementation.Mapping
{
    public static class SupplierMap
    {
        public static ModelBuilder MapSupplier(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Supplier>();
            entity.ToTable("Suppliers");
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.Name);
            entity.Property(x => x.Description);
            entity.Property(x => x.Note);
            entity.Property(x => x.IsDeleted);
            entity.Property(x => x.IsEnabled);
            entity.Property(c => c.CreateDate);
            entity.Property(c => c.UpdateDate);

            entity.Property(x => x.Address).IsRequired();
            entity.Property(x => x.PhoneNo).IsRequired();
            return modelBuilder;
        }
    }
}
