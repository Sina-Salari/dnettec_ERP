using Kernel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Persistence.WorkFlowSteps.Configurations
{
    public class WorkFlowStepConfigurations
        : IEntityTypeConfiguration<WorkFlowStep>
    {
        public void Configure(EntityTypeBuilder<WorkFlowStep> builder)
        {
            builder
                .HasMany(current => current.ValidationStepTrues)
                .WithOne(current => current.WorkFlowStep)
                .HasForeignKey(p => p.WorkFlowStepId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(current => current.ValidationStepFalses)
                .WithOne(p=>p.WorkFlowStep)
                .HasForeignKey(p => p.WorkFlowStepId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
