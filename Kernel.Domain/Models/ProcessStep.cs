using Kernel.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using static Kernel.Domain.Enums.Enums;

namespace Kernel.Domain.Models
{
    public class ProcessStep : BaseEntity
    {
        public string Query { get; set; }
        public ProcessType ProcessType { get; set; }

        public Guid ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        public virtual Application Application { get; set; }
    }
}
