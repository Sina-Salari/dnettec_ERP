using Kernel.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Domain.Models
{
    public class WorkFlow : BaseEntity
    {
        public string Name { get; set; }

        public Guid ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        public virtual Application Application { get; set; }

        public virtual List<WorkFlowStep> WorkFlowSteps { get; set; }
        public virtual WorkFlowResponse WorkFlowResponse { get; set; }
        public virtual WorkFlowInput WorkFlowInput { get; set; }
    }
}
