using Microsoft.EntityFrameworkCore;
using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.DataAccess.Implementation.Mapping
{
    public static class ItemMap
    {
        public static ModelBuilder MapItem(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Item>();
            entity.ToTable("Items");
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.Name);
            entity.Property(x => x.Description);
            entity.Property(x => x.Note);
            entity.Property(x => x.IsDeleted);
            entity.Property(x => x.IsEnabled);
            entity.Property(c => c.CreateDate);
            entity.Property(c => c.UpdateDate);

            entity.Property(x => x.SKU);
            entity.Property(x => x.Unit);
            entity.Property(x => x.Cost);
            entity.Property(x => x.Barcode).IsRequired();

            entity.HasMany(x => x.ItemSupplier)
                .WithOne(x => x.Item)
                .HasForeignKey(x => x.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

            return modelBuilder;
        }
    }
}
