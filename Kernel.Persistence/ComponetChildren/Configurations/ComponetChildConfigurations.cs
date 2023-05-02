using Kernel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Persistence.ComponetChildren.Configurations
{
    public class ComponetChildConfigurations
        : IEntityTypeConfiguration<Domain.Models.ComponetChild>
    {
        public void Configure(EntityTypeBuilder<ComponetChild> builder)
        {
            builder
                .HasOne(current => current.ChildComponent)
                .WithMany(current => current.ChildComponents)
                .HasForeignKey(p => p.ChildComponentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(current => current.ParentComponent)
                .WithMany(current => current.ParentComponents)
                .HasForeignKey(p => p.ParentComponentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
