using Kernel.Domain.Models.Base;

namespace Kernel.Domain.Models
{
    public class Message : BaseEntity
    {
        public Message()
        {
            LangMessages = new List<LangMessage>();
            EntityFieldValidations = new List<EntityFieldValidation>();
            PageTitles = new List<Page>();
            PlaceholderComponentItemOption = new List<ComponentItemOption>();
        }

        public string Name { get; set; }

        public virtual List<LangMessage> LangMessages { get; set; }
        public virtual List<EntityFieldValidation> EntityFieldValidations { get; set; }
        public virtual List<Page> PageTitles { get; set; }
        public virtual List<ComponentItemOption> PlaceholderComponentItemOption { get; set; }
    }
}
