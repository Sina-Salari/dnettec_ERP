using Kernel.Domain.Models.Base;

namespace Kernel.Domain.Models
{
    public class ValidationStep : BaseEntity
    {
        public string Query { get; set; }

        public virtual ValidationStepTrue ValidationStepTrue { get; set; }
        public virtual ValidationStepFalse ValidationStepFalse { get; set; }
    }
}
