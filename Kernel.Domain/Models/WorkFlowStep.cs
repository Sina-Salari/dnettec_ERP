using Kernel.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using static Kernel.Domain.Enums.Enums;

namespace Kernel.Domain.Models
{
    public class WorkFlowStep : BaseEntity
    {
        public bool IsFirst { get; set; }

        public Guid RecordId { get; set; }
        public WorkFlowStepType RecordType { get; set; }

        public Guid WorkFlowId { get; set; }
        [ForeignKey("WorkFlowId")]
        public virtual WorkFlow WorkFlow { get; set; }

        public virtual List<WorkFlowStepMovment> WorkFlowStepMovments { get; set; }
        public virtual List<WorkFlowStepMovment> WorkFlowNextStepMovments { get; set; }
    }
}
