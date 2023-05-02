using Kernel.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Domain.Models
{
    public class ComponetChild : BaseEntity
    {
        public Guid ParentComponentId { get; set; }
        [ForeignKey("ParentComponentId")]
        public virtual Component ParentComponent { get; set; }

        public Guid ChildComponentId { get; set; }
        [ForeignKey("ChildComponentId")]
        public virtual Component ChildComponent { get; set; }
    }
}
