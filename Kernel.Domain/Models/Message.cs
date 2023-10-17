using Kernel.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Domain.Models
{
    public class Message : BaseEntity
    {
        public Message()
        {
            LangMessages = new List<LangMessage>();
            PageTitles = new List<Page>();
            PlaceholderComponentItemOption = new List<ComponentItemOption>();
        }

        public string Name { get; set; }

        public Guid ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        public virtual Application Application { get; set; }

        public virtual List<LangMessage> LangMessages { get; set; }
        public virtual List<Page> PageTitles { get; set; }
        public virtual List<ComponentItemOption> PlaceholderComponentItemOption { get; set; }
    }
}
