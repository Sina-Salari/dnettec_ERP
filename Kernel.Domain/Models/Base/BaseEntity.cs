using Dnettec.Domain;
using Dnettec.Persistence.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Domain.Models.Base
{
    public class BaseEntity : IBaseEntity
    {
        protected BaseEntity() : base()
        {
            Id = new Guid();
            IsBase = false;
            Status = RecordStatus.IsActive;
        }

        public Guid Id { get; set; }
        public bool IsBase { get; set; }
        public RecordStatus Status { get; set; }
    }
}
