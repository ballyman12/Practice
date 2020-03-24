using Microsoft.EntityFrameworkCore;
using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.DataAccess.Implementation.Mapping
{
    public static class UserStateMap
    {
        public static ModelBuilder MapUserState(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<UserState>();
            entity.ToTable("UserState");
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.Type);
            entity.Property(x => x.IsDeleted);
            entity.Property(x => x.IsEnabled);
            entity.Property(c => c.CreateDate);
            entity.Property(c => c.UpdateDate);

            entity.Property(x => x.UserId).IsRequired();

            return modelBuilder;
        }
    }
}
