using Kernel.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Domain.Models
{
    public class ValidationStepFalse : BaseEntity
    {
        public Guid ValidationStepId { get; set; }
        [ForeignKey("ValidationStepId")]
        public virtual ValidationStep ValidationStep { get; set; }

        public Guid WorkFlowStepId { get; set; }
        [ForeignKey("WorkFlowStepId")]
        public virtual WorkFlowStep WorkFlowStep { get; set; }
    }
}
