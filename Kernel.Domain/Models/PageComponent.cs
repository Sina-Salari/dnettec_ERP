using Kernel.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Domain.Models
{
    public class PageComponent : BaseEntity
    {
        public Guid PageId { get; set; }
        [ForeignKey("PageId")]
        public virtual Page Page { get; set; }

        public Guid ComponentId { get; set; }
        [ForeignKey("ComponentId")]
        public virtual Component Component { get; set; }
    }
}
