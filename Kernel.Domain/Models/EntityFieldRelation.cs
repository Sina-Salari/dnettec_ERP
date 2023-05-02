using Kernel.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Domain.Models
{
    public class EntityFieldRelation : BaseEntity
    {
        public Guid EntityId { get; set; }
        [ForeignKey("EntityId")]
        public virtual Entity Entity { get; set; }

        public Guid EntityFieldId { get; set; }
        [ForeignKey("EntityFieldId")]
        public virtual EntityField EntityField { get; set; }
    }
}
