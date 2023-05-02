using Kernel.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Domain.Models
{
    public class MessageStep : BaseEntity
    {
        public Guid MessageId { get; set; }
        [ForeignKey("MessageId")]
        public virtual Message Message { get; set; }
    }
}
