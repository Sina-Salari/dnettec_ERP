using Kernel.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Domain.Models
{
    public class Entity : BaseEntity
    {
        public Entity()
        {
            EntityFields = new List<EntityField>();
            EntityFieldRelations = new List<EntityFieldRelation>();
        }

        public string EntityName { get; set; }

        public Guid ApplicationId { get; set; }
        [ForeignKey("ApplicationId")]
        public virtual Application Application { get; set; }

        public virtual List<EntityField> EntityFields { get; set; }
        public virtual List<EntityFieldRelation> EntityFieldRelations { get; set; }
    }
}
