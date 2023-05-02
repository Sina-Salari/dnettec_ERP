using Kernel.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Domain.Models
{
    public class EntityFieldValidation : BaseEntity
    {
        public string Regex { get; set; }

        public Guid EntityFieldId { get; set; }
        [ForeignKey("EntityFieldId")]
        public virtual EntityField EntityField { get; set; }

        public Guid MessageId { get; set; }
        [ForeignKey("MessageId")]
        public Message Message { get; set; }
    }
}
