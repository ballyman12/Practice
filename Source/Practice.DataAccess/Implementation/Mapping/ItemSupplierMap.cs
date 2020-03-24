using Microsoft.EntityFrameworkCore;
using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.DataAccess.Implementation.Mapping
{
    public static class ItemSupplierMap
    {
        public static ModelBuilder MapItemSupplier(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ItemSupplier>();
            entity.ToTable("ItemSuppliers");
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.Name);
            entity.Property(x => x.Description);
            entity.Property(x => x.Note);
            entity.Property(x => x.IsDeleted);
            entity.Property(x => x.IsEnabled);
            entity.Property(c => c.CreateDate);
            entity.Property(c => c.UpdateDate);

            entity.HasOne(x => x.Supplier)
                .WithMany()
                .HasForeignKey(x => x.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);

            return modelBuilder;
        }
    }
}
