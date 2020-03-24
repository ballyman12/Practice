using Microsoft.EntityFrameworkCore;
using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.DataAccess.Implementation.Mapping
{
    public static class ItemStateMap
    {
        public static ModelBuilder MapItemState(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ItemState>();
            entity.ToTable("ItemState");
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.Type);
            entity.Property(x => x.IsDeleted);
            entity.Property(x => x.IsEnabled);
            entity.Property(c => c.CreateDate);
            entity.Property(c => c.UpdateDate);

            entity.Property(x => x.ItemId).IsRequired();

            return modelBuilder;
        }
    }
}
