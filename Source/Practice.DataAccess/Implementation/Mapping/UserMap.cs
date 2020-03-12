using Microsoft.EntityFrameworkCore;
using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.DataAccess.Implementation.Mapping
{
    public static class UserMap
    {
        public static ModelBuilder MapUser(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<User>();
            entity.ToTable("Users");
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.Name).HasMaxLength(30).IsRequired();
            entity.Property(x => x.Note);
            entity.Property(x => x.Password).IsRequired();
            entity.Property(x => x.SecurityToken).IsRequired();
            entity.Property(x => x.Description);
            entity.Property(x => x.IsDeleted);
            entity.Property(x => x.IsEnabled);
            return modelBuilder;
        }
    }
}
