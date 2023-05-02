using Kernel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Persistence.WorkFlowStepMovments.Configurations
{
    public class WorkFlowStepMovmentConfigurations
        : IEntityTypeConfiguration<WorkFlowStepMovment>
    {
        public void Configure(EntityTypeBuilder<WorkFlowStepMovment> builder)
        {
            builder
                .HasOne(current => current.WorkFlowStep)
                .WithMany(p=>p.WorkFlowStepMovments)
                .HasForeignKey(p => p.WorkFlowStepId)
                .OnDelete(DeleteBehavior.NoAction);


            builder
                .HasOne(current => current.WorkFlowNextStep)
                .WithMany(p => p.WorkFlowNextStepMovments)
                .HasForeignKey(p => p.WorkFlowNextStepId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
