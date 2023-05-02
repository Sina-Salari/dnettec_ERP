using Kernel.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Domain.Models
{
    public class ComponentItem : BaseEntity
    {
        public Guid ComponentId { get; set; }
        [ForeignKey("ComponentId")]
        public virtual Component Component { get; set; }

        public Enums.Enums.ComponentItemType ComponentItemType { get; set; }

        public virtual ComponentItemOption ComponentItemOption { get; set; }
    }
}
