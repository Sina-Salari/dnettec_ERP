using Kernel.Domain.Models.Base;

namespace Kernel.Domain.Models
{
    public class WorkFlow : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<WorkFlowStep> WorkFlowSteps { get; set; }
        public virtual WorkFlowResponse WorkFlowResponse { get; set; }
        public virtual WorkFlowInput WorkFlowInput { get; set; }
    }
}
