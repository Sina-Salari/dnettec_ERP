using Kernel.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Domain.Models
{
    public class ComponentItemOption : BaseEntity
    {
        public Guid ComponentItemId { get; set; }
        [ForeignKey("ComponentItemId")]
        public virtual ComponentItem ComponentItem { get; set; }

        public string Classes { get; set; }

        public Guid PlaceholderId { get; set; }
        [ForeignKey("PlaceholderId")]
        public virtual Message Placeholder { get; set; }
    }
}
