using Kernel.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Domain.Models
{
    public class WorkFlowResponse : BaseEntity
    {
        public string ResponseJson { get; set; }

        public Guid WorkFlowId { get; set; }
        [ForeignKey("WorkFlowId")]
        public virtual WorkFlow WorkFlow { get; set; }
    }
}
