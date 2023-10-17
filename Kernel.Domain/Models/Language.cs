using Kernel.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Domain.Models
{
    public class Language : BaseEntity
    {
        public string Code { get; set; }

        public Guid ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        public virtual Application Application { get; set; }

        public virtual List<LangMessage> LangMessages { get; set; }
    }
}
