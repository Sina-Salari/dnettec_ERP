using Kernel.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Domain.Models
{
    public class RequestPattern : BaseEntity
    {
        public string Controller { get; set; }
        public string Action { get; set; }

        public Guid WorkFlowId { get; set; }
        [ForeignKey("WorkFlowId")]
        public virtual WorkFlow WorkFlow { get; set; }
    }
}
