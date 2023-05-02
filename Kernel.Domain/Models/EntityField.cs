using Kernel.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kernel.Domain.Models
{
    public class EntityField : BaseEntity
    {
        public EntityField()
        {
            EntityFieldValidations = new List<EntityFieldValidation>();
            EntityFieldRelations = new List<EntityFieldRelation>();
        }

        public string FieldName { get;  set; }

        public Enums.Enums.FieldType FeildType { get;  set; }

        public bool IsRequired { get;  set; } = true;
        public bool IsDuplicate { get;  set; } = false;

        public Guid EntityId { get;  set; }
        [ForeignKey("EntityId")]
        public virtual Entity Entity { get;  set; }

        public virtual List<EntityFieldValidation> EntityFieldValidations { get;  set; }
        public virtual List<EntityFieldRelation> EntityFieldRelations { get;  set; }
    }
}
