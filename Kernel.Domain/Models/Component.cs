using Kernel.Domain.Models.Base;

namespace Kernel.Domain.Models
{
    public class Component : BaseEntity
    {
        public string Size { get; set; }
        public string Classes { get; set; }
        public Enums.Enums.ComponentDirectionType ComponentDirectionType { get; set; }

        public virtual List<ComponetChild> ParentComponents { get; set; }
        public virtual List<ComponetChild> ChildComponents { get; set; }
        public virtual List<ComponentItem> ComponentItems { get; set; }
    }
}
