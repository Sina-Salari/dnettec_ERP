using Kernel.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Domain.Models
{
    public class WorkFlowStepMovment : BaseEntity
    {
        public Guid WorkFlowStepId { get; set; }
        [ForeignKey("WorkFlowStepId")]
        public virtual WorkFlowStep WorkFlowStep { get; set; }

        public Guid WorkFlowNextStepId { get; set; }
        [ForeignKey("WorkFlowNextStepId")]
        public virtual WorkFlowStep WorkFlowNextStep { get; set; }
    }
}
