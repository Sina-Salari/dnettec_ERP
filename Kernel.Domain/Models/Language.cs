using Kernel.Domain.Models.Base;

namespace Kernel.Domain.Models
{
    public class Language : BaseEntity
    {
        public string Code { get; set; }

        public virtual List<LangMessage> LangMessages { get; set; }
    }
}
