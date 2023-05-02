using Kernel.Domain.Models.Base;
using static Kernel.Domain.Enums.Enums;

namespace Kernel.Domain.Models
{
    public class ProcessStep : BaseEntity
    {
        public string Query { get; set; }
        public ProcessType ProcessType { get; set; }
    }
}
