using Kernel.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Domain.Models
{
    public class ValidationStep : BaseEntity
    {
        public string Query { get; set; }

        public Guid ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        public virtual Application Application { get; set; }

        public virtual ValidationStepTrue ValidationStepTrue { get; set; }
        public virtual ValidationStepFalse ValidationStepFalse { get; set; }
    }
}
