using Microsoft.EntityFrameworkCore;
using Practice.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.DataAccess.Implementation.Mapping
{
    public static class ActionStateMap
    {
        public static ModelBuilder MapActionState(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ActionState>();
            entity.ToTable("ActionStates");

            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.Property(x => x.By).IsRequired();
            entity.Property(x => x.On).IsRequired();

            return modelBuilder;
        }
    }
}
