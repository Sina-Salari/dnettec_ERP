using Kernel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Persistence.EntityFieldRelations.Configurations
{
    public class EntityFieldRelationConfigurations
        : IEntityTypeConfiguration<EntityFieldRelation>
    {
        public void Configure(EntityTypeBuilder<EntityFieldRelation> builder)
        {
            builder
                .HasOne(current => current.Entity)
                .WithMany(current => current.EntityFieldRelations)
                .HasForeignKey(p => p.EntityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(current => current.EntityField)
                .WithMany(p=>p.EntityFieldRelations)
                .HasForeignKey(p => p.EntityFieldId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
