using Kernel.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Domain.Models
{
    public class LangMessage : BaseEntity
    {
        public string MessageText { get; set; }


        public Guid MessageId { get; set; }
        [ForeignKey("MessageId")]
        public virtual Message Message { get; set; }

        public Guid LanguageId { get; set; }
        [ForeignKey("LanguageId")]
        public virtual Language Language { get; set; }
    }
}
