using Kernel.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Domain.Models
{
    public class Page : BaseEntity
    {
        public Guid PageTitleId { get; set; }
        [ForeignKey("PageTitleId")]
        public virtual Message PageTitle { get; set; }

        public string URL { get; set; }
        public string Classes { get; set; }
    }
}